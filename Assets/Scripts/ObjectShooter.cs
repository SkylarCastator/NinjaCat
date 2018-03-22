using UnityEngine;
using System.Collections;

public class ObjectShooter : MonoBehaviour {

	public GameObject[] shootableObjects;
	public Vector3 throwDiff;
	public float maxHeightDifference;
	public bool gameFinished = false;
	
	public float fireRate = 3.0f;
	private float nextFire = 0.0f;
	
	void Update()
	{
		if (!gameFinished)
		{
			if (Time.time > nextFire) 
			{
				//Vector2 rndThrow = new Vector2(Random.Range(-throwDiff.x,throwDiff.x), Random.Range(throwDiff.y,throwDiff.y*2));
				nextFire = Time.time + fireRate + (Random.Range(-3,3));
				int spawnObjectNumber = Random.Range(0, shootableObjects.Length);
				float heighDifference = Random.Range(-maxHeightDifference,maxHeightDifference);
				Vector3 tossingHeight = new Vector3(transform.position.x, transform.position.y + heighDifference, transform.position.z);
				ShootObject(shootableObjects[spawnObjectNumber]);
			}
		}
	}

	public void ShootObject(GameObject spawnableObject)
	{
		GameObject orangeClone;
		orangeClone = Instantiate(spawnableObject, transform.position, spawnableObject.transform.rotation) as GameObject;
		orangeClone.GetComponent<Rigidbody>().velocity = new Vector3(throwDiff.x,  throwDiff.y, throwDiff.z);
		orangeClone.transform.parent = transform.parent;
	}
}