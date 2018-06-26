using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCode : MonoBehaviour {

	public float speed = 1f;

	public float boundaryTop = 8f;
	public float boundaryBottom = -8f;
	public float boundaryLeft = -8f;
	public float boundaryRight = 8f;

	private Animator anim;

	public GameObject StatsCode;
	private Stats SC;
	private bool EggLeft = true;

	public GameObject Kipje;
	public bool HoldingKipje;

	private AudioSource AS;
	public AudioClip EggCrack;

	public GameObject Information;
	private RawImage II;
	public Texture TextImage;
	private bool showInfo = false;

	void Awake(){
		anim = GetComponent<Animator> ();
		SC = StatsCode.GetComponent<Stats> ();
		AS = GetComponent<AudioSource> ();
		II = Information.GetComponent<RawImage> ();
	}

	// Update is called once per frame
	void Update () {
		Walk ();
		CheckKipje ();
	}

	void Walk(){
		float X = 0;
		float Y = 0;

		//UP
		if (Input.GetKey (KeyCode.W) && transform.position.y <= boundaryTop) {
			Y = speed * Time.deltaTime;
			anim.SetBool ("Up", true);
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Down", false);
			anim.SetBool ("Idle", false);
		}
		//Down
		if(Input.GetKey(KeyCode.S) && transform.position.y >= boundaryBottom){
			Y = -speed * Time.deltaTime;
			anim.SetBool ("Up", false);
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Down", true);
			anim.SetBool ("Idle", false);
		}
		//Left
		if(Input.GetKey(KeyCode.A) && transform.position.x >= boundaryLeft){
			X = -speed * Time.deltaTime;
			anim.SetBool ("Up", false);
			anim.SetBool ("Left", true);
			anim.SetBool ("Right", false);
			anim.SetBool ("Down", false);
			anim.SetBool ("Idle", false);
		}
		//Right
		if(Input.GetKey(KeyCode.D) && transform.position.x <= boundaryRight){
			X = speed * Time.deltaTime;
			anim.SetBool ("Up", false);
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", true);
			anim.SetBool ("Down", false);
			anim.SetBool ("Idle", false);
		}
		Vector3 lastPos = transform.position;	

		//Walk
		transform.Translate (X, Y, 0);

		if (lastPos == transform.position) {
			anim.SetBool ("Up", false);
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("Down", false);
			anim.SetBool ("Idle", true);
		}
	}

	void CheckKipje(){
		if(Input.GetKey(KeyCode.Space) && Kipje != null){
			Kipje.transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z - 1);
			HoldingKipje = true;
		}
		if (Input.GetKeyUp (KeyCode.Space) && Kipje != null){
			Kipje.transform.position = new Vector3 (transform.position.x, transform.position.y - 0.5f, transform.position.z);
			HoldingKipje = false;
		}
	}

	void OnTriggerEnter2D(Collider2D Target){
		if (Target.gameObject.tag == "AanvallendEI" && EggLeft) {
			SC.CurrentLives -= 1;
			EggLeft = false;
			AS.PlayOneShot (EggCrack);
		}
		if (Target.gameObject.tag == "Kipje" && !HoldingKipje) {
			Kipje = Target.gameObject;
		}
	}
	void OnTriggerExit2D(Collider2D Target){
		if (Target.gameObject.tag == "AanvallendEI") {
			EggLeft = true;
		}
		if (Target.gameObject == Kipje) {
			Kipje = null;
			HoldingKipje = false;
		}
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
