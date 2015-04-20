using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	public float suavidade;
	public float alturaCamera;
	public float proximidadeCamera;
	public float posicaoCamera;

	public Transform player;
	public bool podeMover;

	private Vector3 distanciaCameraPlayer;

	// Use this for initialization
	void Start () {
		player = (Transform) (GameObject.FindGameObjectWithTag ("Player")).GetComponent("Transform");
		distanciaCameraPlayer = transform.position - player.position;
		podeMover = false;
		//suavidade = ((Andar) (GameObject.FindGameObjectWithTag ("Player")).GetComponent("Andar")).moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(podeMover){
			Vector3 tg = player.position + distanciaCameraPlayer;
			tg.y += alturaCamera; 
			tg.x -= proximidadeCamera; 
			tg.z -= posicaoCamera; 

			transform.position = Vector3.Lerp(transform.position, tg, Time.deltaTime*suavidade); 
		}
	}
}
