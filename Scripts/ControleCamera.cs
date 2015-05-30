using UnityEngine;
using System.Collections;

public class ControleCamera : MonoBehaviour {
	public bool podeMover;
	public CameraMover scriptCamera;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals("Player")) {
			if(podeMover)
				scriptCamera.podeMover = true;
			else
				scriptCamera.podeMover = false;
		}
	}
}
