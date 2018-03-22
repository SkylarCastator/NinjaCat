using UnityEngine;
using System.Collections;

public class NinjaSlicer : MonoBehaviour {

	public MenuControl menuScript;
	public ObjectShooter[] shooters;
	public GameObject mainLight;
	public float multiplier = 2.0f;
	private GameObject mainCamera;
	public Vector2 XYraw = Vector2.zero;
	public Vector2 XYfixed = Vector2.zero;
	public Vector2 XYmin = Vector2.zero;
	public Vector2 XYmax = Vector2.zero;
	
	public Vector2 XYprev = Vector2.zero;
	public Vector2 XYdiff = Vector2.zero;
	
	public GameObject sparks;
	public GameObject burns;
	public float smoothTime = 0.3f;
	public GameObject follower;
	private float lightVelocity = 0.0f;
	public float followSpeed = 0.3f;
	private Vector3 followerVelocity = Vector3.zero;
	public GameObject player;
	private Material playerColor;

	void Awake()
	{
		playerColor = player.GetComponent<Renderer>().material;
		mainCamera = GameObject.Find("Main Camera");
	}
	
	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.layer == 9)
		{
			ShootableObjectScript objectScript = other.transform.gameObject.GetComponent("ShootableObjectScript") as ShootableObjectScript;
			objectScript.XYdiff = XYdiff;
			objectScript.explode();
			objectScript.DestroyShootingObject();
			menuScript.ChangeCutFruitCounter(1);
		}
		else if (other.gameObject.layer == 10)
		{
			ObsticleObjectScript objectScript = other.transform.gameObject.GetComponent("ObsticleObjectScript") as ObsticleObjectScript;
			objectScript.XYdiff = XYdiff;
			objectScript.explode();

			if (!catNipPowerUp)
			{
				menuScript.CatDamaged();
			}
		}
		else if (other.gameObject.layer == 11)
		{
			AudioSource[] Music = mainCamera.GetComponents<AudioSource>();
			Music[0].Pause();
			Music[1].Play();
			catNipPowerUp = true;
			adjustShooters(-1000, 0.5F);
			StartCoroutine(catNipPower());
			StartCoroutine(catNipPowerTimer());
		}
		else if (other.gameObject.layer == 12)
		{
			ObsticleObjectScript objectScript = other.transform.gameObject.GetComponent("ObsticleObjectScript") as ObsticleObjectScript;
			objectScript.explode();
			menuScript.ChangeCutFruitCounter(1);
		}
	}

	void adjustShooters(int throwDiff, float fireRate)
	{
		for (int i = 0; i < shooters.Length; i++)
		{
			shooters[i].throwDiff = new Vector3(throwDiff, 10f, 10f);
			shooters[i].fireRate = fireRate;
		}
	}

	void ChangeMusic()
	{
		//AudioSource gameMusic = Camera.main.GetComponents("AudioSource") as AudioSource;
	}
	
	void Update () 
	{
		//follower.transform.position = Vector3.SmoothDamp(follower.transform.position, gameObject.transform.position, followerVelocity, followSpeed);

		XYraw = new Vector2(transform.position.x, transform.position.y);//MAIN INPUT
		
		//float newBrightness = Mathf.SmoothDamp(mainLight.GetComponent(Light).intensity, Vector2.Distance(XYraw, XYprev)*0.1,
		  //                                           lightVelocity, smoothTime);
		
		//newBrightness = Mathf.Clamp(newBrightness, 0.1f,3.0f);
		
		//mainLight.GetComponent(Light).intensity = newBrightness;
		//Debug.Log(Vector2.Distance(XYraw, XYprev));
		
		/*if(newBrightness > 0.5f){
			Instantiate(burns, transform.position, transform.rotation);
			if(audio.isPlaying == false){
				audio.pitch = newBrightness;
				audio.Play();
				
			}
		}*/
		
		
		
		XYdiff = new Vector2((XYraw.x-XYprev.x)*multiplier,(XYraw.y-XYprev.y)*multiplier);
		XYprev = XYraw;
	}

	private Color rainbowColor;
	public bool catNipPowerUp = false;

	IEnumerator catNipPowerTimer() 
	{
		yield return new WaitForSeconds (6f);
		AudioSource[] Music = mainCamera.GetComponents<AudioSource>();
		Music[1].Stop();
		Music[0].Play();
		catNipPowerUp = false;
		adjustShooters(-500, 3F);
		playerColor.color = new Color(1f, 1f, 1f, 1f);
	}

	IEnumerator catNipPower() 
	{
		int i = 0;
		while (catNipPowerUp) 
		{
			ChooseRainbowColor(i);

			if (i <= 5)
			{
				i += 1;
			}
			else
			{
				i = 0;
			}

			yield return new WaitForSeconds (0.05f);
		 }
	}

	void ChooseRainbowColor(int i)
	{
		if (i == 0)
		{
			playerColor.color = new Color(1f, 0f, 0f, 1f);
		}
		else if (i == 1)
		{
			playerColor.color = new Color(0f, 1f, 0f, 1f);
		}
		else if (i == 2)
		{
			playerColor.color = new Color(0f, 0f, 1f, 1f);
		}
		else if (i == 3)
		{
			playerColor.color = new Color(1f, 0.4f, 0f, 1f);
		}
		else if (i == 4)
		{
			playerColor.color = new Color(0f, 1f, 1f, 1f);;
		}
		else if (i == 5)
		{
			playerColor.color = new Color(1f, 0f, 1f, 1f);;
		}
	}
}
