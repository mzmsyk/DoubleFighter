using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
	public int reflections;
	public float maxLength;

	private LineRenderer lineRenderer;
	private Ray ray;
	private RaycastHit hit;
	private Vector3 direction;

	[SerializeField] private LayerMask collisionLayer;
	private void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	private void Update()
	{
		ray = new Ray(transform.position, transform.forward);

		lineRenderer.positionCount = 1;
		lineRenderer.SetPosition(0, transform.position);
		float remainingLength = maxLength;

		for (int i = 0; i < reflections; i++)
		{
			if (Physics.Raycast(ray.origin, ray.direction *10, out hit, 100, collisionLayer))
			{
				Debug.Log(hit.transform.gameObject.name);
				lineRenderer.positionCount += 1;
				lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
				remainingLength -= Vector3.Distance(ray.origin, hit.point);

				ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal) * 10);
				Debug.DrawRay(ray.origin, ray.direction * ray.direction.magnitude, Color.red);
				
			}
			else
			{
				lineRenderer.positionCount += 1;
				lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction);
			}
		}
	}
}