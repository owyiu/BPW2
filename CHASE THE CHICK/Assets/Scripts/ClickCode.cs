using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCode : MonoBehaviour {

	public GameObject Information;
	private RawImage II;
	public Texture TextImage;
	private bool showInfo = false;

	// Use this for initialization
	void Awake () {
		II = Information.GetComponent<RawImage> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (showInfo) {
			showInfo = false;
		}
		else if (!showInfo) {
			showInfo = true;
		}
		if (showInfo) {
			Information.SetActive (true);
			II.texture = TextImage;
		}
		if (!showInfo) {
			Information.SetActive (false);
		}
	}
}
