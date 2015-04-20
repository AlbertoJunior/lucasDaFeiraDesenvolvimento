using UnityEngine;
using System.Collections;

public class ControleCamera : MonoBehaviour {
	public bool podeMover;
	public CameraMover scriptCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals("Player")) {
			if(podeMover)
				scriptCamera.podeMover = true;
			else
				scriptCamera.podeMover = false;
		}
	}
}
