using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {

	public UILabel timerLabel;
	public UILabel numberOfCutObjectsLabel;
	public UILabel numberOfCutObjectsFinalLabel;
	public float clockLimit;
	private int numberOfCutObjects = 0;
	public GameObject[] catLives;
	public int catLivesAmount = 3;
	public bool gameEnded = false;
	public GameObject gameOverLabel;
	public GameObject winnerMenu;
	public ObjectShooter[] shooters;
	public GameObject bonusObject;

	void Start () 
	{
		timerLabel.text = clockLimit.ToString();
		numberOfCutObjectsLabel.text = numberOfCutObjects.ToString();
	}
	
	void Update () 
	{
		if (!gameEnded)
		{
			MaintainClock();
		}
	}

	void MaintainClock()
	{
		if (clockLimit >= 0)
		{
			clockLimit  = clockLimit - Time.deltaTime;
			int minTimer = (int)clockLimit / 60;
			int secTimer = (int)clockLimit - (minTimer * 60);
			string timerOutput = minTimer.ToString() + ":" + secTimer.ToString();
			timerLabel.text = timerOutput;
		}
		else
		{
			if (!TimerStopped)
			{
				TimerFinished();
			}
		}
	}

	public void ChangeCutFruitCounter(int amount)
	{
		numberOfCutObjects += amount;
		numberOfCutObjectsLabel.text = numberOfCutObjects.ToString();
	}

	bool TimerStopped = false;

	void TimerFinished()
	{
		TimerStopped = true;

		for (int i = 0; i < shooters.Length; i++)
		{
			shooters[i].gameFinished = true;
		}

		int RandomShooterNumber  = Random.Range(0, shooters.Length - 1);
		shooters[RandomShooterNumber].throwDiff = new Vector3(-250, 10f, 10f);
		shooters[RandomShooterNumber].ShootObject(bonusObject);

		StartCoroutine(FinishingBonus());
	}

	IEnumerator FinishingBonus()
	{
		yield return new WaitForSeconds (3f);
		ShowWinnerMenu();
	}

	public void CatDamaged()
	{
		if (catLivesAmount > 0)
		{
			catLivesAmount -= 1;
			catLives[catLivesAmount].SetActive(false);
		}
		else
		{
			gameEnded = true;
			EndGame();
		}
	}

	void ShowWinnerMenu()
	{
		winnerMenu.SetActive(true);
		numberOfCutObjectsFinalLabel.text = numberOfCutObjects.ToString();
	}

	void EndGame()
	{
		for (int i = 0; i < shooters.Length; i++)
		{
			shooters[i].gameFinished = true;
		}

		gameOverLabel.SetActive(true);
	}

	public void ResetLevel()
	{
		Application.LoadLevel ("level02");
	}
}
