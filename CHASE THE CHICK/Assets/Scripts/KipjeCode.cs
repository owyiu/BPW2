using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KipjeCode : MonoBehaviour {

	public GameObject StatsCode;
	private Stats SC;

	void Awake () {
		StatsCode = GameObject.Find ("Stats");
		SC = StatsCode.GetComponent<Stats> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D Target){
		if (Target.gameObject.tag == "Deurmat") {
			SC.AmountKipjes += 1;
			Destroy (gameObject);
		}
	}
}
