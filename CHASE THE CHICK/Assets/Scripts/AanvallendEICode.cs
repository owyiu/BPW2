using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AanvallendEICode : MonoBehaviour {

	public float speed = 5f;

	private float Rotation;

	private Animator anim;

	void Awake(){
		Rotation = Random.Range (0, 360);

		transform.localEulerAngles = new Vector3 (0, 0, Rotation);
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Movement
		transform.Translate((speed * Time.deltaTime), 0, 0);
	}

	void OnTriggerEnter2D(Collider2D Target){
		if (Target.gameObject.tag == "Character") {
			anim.Play ("EggDestroy");
			StartCoroutine (DestroyEgg ());
		}
		print ("Ei Collision met: " + Target.gameObject.tag);
	}

	IEnumerator DestroyEgg(){
		yield return new WaitForSeconds (0.2f);
		Destroy (gameObject);
	}

}
