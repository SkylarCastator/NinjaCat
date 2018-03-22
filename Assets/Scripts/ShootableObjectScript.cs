using UnityEngine;
using System.Collections;

public class ShootableObjectScript : MonoBehaviour {
	public bool hit = false;
	//public GameObject slicedFruitL;
	//public GameObject slicedFruitR;
	public Vector3 throwDiff;
	public Vector2 XYdiff;
	public GameObject fruitSlicer;
	public GameObject fireworks;
	public GameObject wallSpray;
	public GameObject splatter00;
	public GameObject splatter01;
	public GameObject splatter02;

	void Start()
	{
		XYdiff = Vector2.zero;
	}

	public void explode(){
		//transform.LookAt(fruitSlicer, Vector3.up);
		float diffX = 5;
		/*
		Rigidbody cloneL;
		GameObject cloneLObject = Instantiate(slicedFruitL, new Vector3(transform.position.x-diffX, transform.position.y,transform.position.z), transform.rotation) as GameObject;
		cloneL = cloneLObject.rigidbody;
		Rigidbody cloneR;
		GameObject cloneRObject = Instantiate(slicedFruitR, new Vector3(transform.position.x+diffX, transform.position.y,transform.position.z), transform.rotation) as GameObject;
		cloneR = cloneRObject.rigidbody;
		cloneL.velocity = new Vector3(XYdiff.x+rigidbody.velocity.x/2,  XYdiff.y+rigidbody.velocity.y/2, 0);

		float rndRot = Random.Range(-100.0f, 100.0f);
		cloneL.gameObject.transform.eulerAngles = new Vector3(rndRot, rndRot, rndRot);
		cloneR.velocity = new Vector3(XYdiff.x, XYdiff.y, 0);
		*/
		Instantiate(fireworks, transform.position, transform.rotation);
		Instantiate(wallSpray, transform.position, transform.rotation);
		
		GameObject splat = null;
		int rndSplat = Random.Range(0,2);
		
		if(rndSplat ==0)
		{
			splat = Instantiate(splatter00, new Vector3(transform.position.x, transform.position.y, 60), Quaternion.Euler(270, 0, 0)) as GameObject;
		}
		else if(rndSplat ==1){
			splat = Instantiate(splatter01, new Vector3(transform.position.x, transform.position.y, 60), Quaternion.Euler(270, 0, 0)) as GameObject;
		}
		else if(rndSplat ==2)
		{
			splat = Instantiate(splatter02, new Vector3(transform.position.x, transform.position.y, 60), Quaternion.Euler(270, 0, 0)) as GameObject;
		}    

		splat.GetComponent<Rigidbody>().velocity = new Vector3(throwDiff.x,  throwDiff.y, 0);

	}

	public void DestroyShootingObject()
	{
		Destroy(gameObject);
	}
}
