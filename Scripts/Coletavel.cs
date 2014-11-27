using UnityEngine;
using System.Collections;

public class Coletavel : MonoBehaviour {
	public GameObject camera = null;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			Debug.Log("pega item ai mano");
			camera.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Player")) {
			Debug.Log("volta ai mano");
			camera.SetActive (false);
		}
	}

	void OnTriggerStay(Collider other) {
		if(Input.GetKey(KeyCode.E)){
			Debug.Log("pegou o item aew!");
			animation.Play("Box_open");
		}
		//if (other.attachedRigidbody)
		//	other.attachedRigidbody.AddForce(Vector3.up * 10);
	}

}
