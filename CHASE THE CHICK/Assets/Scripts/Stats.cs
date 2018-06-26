using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

	public int CurrentLives;
	public int MaxLives = 5;
	public GameObject LivesText;
	private Text LT; 

	public int AmountKipjes = 0;
	public int WinKipjes = 35;
	public GameObject KipjesText;
	private Text KT;

	public float StartTimeSeconds = 120;
	public float CurrentTimeSeconds;
	public GameObject TimeText;
	private Text TT;
	private bool MayCount = true;

	public GameObject WinLoseImage;
	private RawImage WLI;
	public Texture Lost;
	public Texture Won;
	public string WinLose = "";

	void Awake(){
		CurrentLives = MaxLives;
		CurrentTimeSeconds = StartTimeSeconds;

		LT = LivesText.GetComponent<Text> ();
		KT = KipjesText.GetComponent<Text> ();
		TT = TimeText.GetComponent<Text> ();

		WLI = WinLoseImage.GetComponent<RawImage> ();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (DecreaseTime ());
	}
	
	// Update is called once per frame
	void Update () {
		SetStats ();
		CheckWinLose ();
	}

	void SetStats(){
		//Lives
		LT.text = CurrentLives.ToString();
		//Kipjes
		KT.text = AmountKipjes.ToString();
		//Time
		TT.text = (CurrentTimeSeconds / 60 - ((CurrentTimeSeconds % 60) / 60)) + " : " + (CurrentTimeSeconds % 60);
	}

	void CheckWinLose(){
		//Check WinLose conditions
		if (AmountKipjes >= WinKipjes) {
			WinLose = "Win";
			MayCount = false;
		}
		if (CurrentTimeSeconds <= 0 || CurrentLives <= 0) {
			WinLose = "Lose";
			MayCount = false;
		}

		//Set WinLose Images
		if (WinLose == "Win") {
			WinLoseImage.SetActive (true);
			WLI.texture = Won;
		}
		if (WinLose == "Lose") {
			WinLoseImage.SetActive (true);
			WLI.texture = Lost;
		}
		if (WinLose != "Win" && WinLose != "Lose") {
			WinLoseImage.SetActive (false);
		}
	}

	IEnumerator DecreaseTime(){
		yield return new WaitForSeconds (1f);
		if (CurrentTimeSeconds > 0 && MayCount) {
			CurrentTimeSeconds -= 1;
			StartCoroutine (DecreaseTime ());
		}
	}
}
