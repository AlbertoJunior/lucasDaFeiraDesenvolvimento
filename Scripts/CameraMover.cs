using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	public float suavidade;
	public float alturaCamera;
	public float valorFlip;
	public float posicaoCamera;
	public float posicaoCameraFlip;
	public float proximidadeCamera;
	public Transform player;
	public bool podeMover;

	private Vector3 distanciaCameraPlayer;
	private bool flipChar;

	// Use this for initialization
	void Start () {
		distanciaCameraPlayer = transform.position - player.position;
		podeMover = false;
		flipChar = false;
	}
	
	void LateUpdate () {
		if(podeMover){
			Vector3 tg = player.position + distanciaCameraPlayer;
			tg.y += alturaCamera; 
			tg.x -= proximidadeCamera; 
			tg.z -= posicaoCamera + posicaoCameraFlip; 

			transform.position = Vector3.Lerp(transform.position, tg, Time.deltaTime*suavidade); 
		}
	}

	public void flip(){
		if (flipChar) {
			posicaoCameraFlip = 0;
		} 
		else {
			posicaoCameraFlip = 20;
		}
		flipChar = !flipChar;
	}

}
