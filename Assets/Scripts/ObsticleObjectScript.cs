using UnityEngine;
using System.Collections;

public class ObsticleObjectScript : MonoBehaviour {
	public bool hit = false;
	//public GameObject slicedFruitL;
	//public GameObject slicedFruitR;
	public Vector2 XYdiff;
	public GameObject fruitSlicer;
	public GameObject fireworks;
	public GameObject wallSpray;
	public GameObject splatter;
	
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

		Destroy(gameObject);
	}
}
