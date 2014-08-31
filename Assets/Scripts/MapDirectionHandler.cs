using UnityEngine;
using System.Collections;

public class MapDirectionHandler : MonoBehaviour {

	public GameObject shootableObjects;

	public float fireRateMax = 10.0f;
	public float fireRateMin = 4.0f;
	private float nextFire = 0.0f;

	public float maxAngleDifference = 60;
	public float minAngleDifference = -60;
	
	void Update()
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + (Random.Range(fireRateMin,fireRateMax));
			RotateMap();
		}
	}

	void RotateMap()
	{
		float RandomAngle = Random.Range(minAngleDifference, maxAngleDifference);
		transform.RotateAround(Vector3.zero, Vector3.forward, RandomAngle);
		//RandomAngle = Random.Range(minAngleDifference, maxAngleDifference);
		//shootableObjects.transform.RotateAround(Vector3.zero, Vector3.forward, RandomAngle);
	}


}
