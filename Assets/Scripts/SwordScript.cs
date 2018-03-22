using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour {
	private Camera mainCamera;
	public GameObject slicer;
	public Vector2 XY = Vector2.zero;
	public Vector2 XYprev = Vector2.zero;
	public Vector2 XYdiff = Vector2.zero;

	void Awake(){
		mainCamera = Camera.main.GetComponent("Camera") as Camera;
	}

	void Update () 
	{
#if UNITY_EDITOR
		//if (Input.GetMouseButton(0))
		//{
			XY = Input.mousePosition;//CHANGE THIS INPUT TO WORK WITH WHATEVA
			XYdiff = new Vector2(XY.x-XYprev.x,XY.y-XYprev.y);

			Ray ray;
			ray = mainCamera.ScreenPointToRay(XY);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit)) 
			{
				//Debug.Log(hit.transform.gameObject.name);
				//if(hit.transform.gameObject.CompareTag("bg"))
				//{
					slicer.transform.position = new Vector3(hit.point.x, hit.point.y, 0);
				//}
			}

			GetComponent<GUITexture>().pixelInset = new Rect (Input.mousePosition.x -16, Input.mousePosition.y -16, 32, 32);    
			XYprev = XY;
		//}
#else
		if (Input.touchCount > 0)
		{
			Touch touch1 = Input.GetTouch(0);
			XY = touch1.position;
			XYdiff = new Vector2(XY.x-XYprev.x,XY.y-XYprev.y);
			
			Ray ray;
			ray = mainCamera.ScreenPointToRay(XY);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit)) 
			{
				if(hit.transform.gameObject.CompareTag("bg"))
				{
					slicer.transform.position = new Vector3(hit.point.x, hit.point.y, 0);
				}
			}
			
			guiTexture.pixelInset = new Rect (Input.mousePosition.x -16, Input.mousePosition.y -16, 32, 32);    
			XYprev = XY;
		}
#endif
	}
}