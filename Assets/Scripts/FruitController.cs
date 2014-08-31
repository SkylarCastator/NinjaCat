using UnityEngine;
using System.Collections;

public class FruitController : MonoBehaviour {

	public MenuControl menuScript;
	
	public void ChangeCutFruitCounter(int amount)
	{
		menuScript.ChangeCutFruitCounter(amount);
	}
}
