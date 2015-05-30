using UnityEngine;
using System.Collections;

public class InimigoIA : Movimentavel {
	public GameObject player;
	public float distanciaVisao;

	private bool isRight;
	private bool endOfRight;

	public float tempoEspera;
	private float tempoEsperando;

	// Use this for initialization
	private void Start () {
		base.Start ();
		isRight = true;
		endOfRight = false;
		tempoEspera = 0;
	}

	// Update is called once per frame
	private void Update () {
		Ray2D ray2d = new Ray2D (transform.position, Vector3.forward);
		Debug.DrawRay (ray2d.origin, ray2d.direction*distanciaVisao, Color.green);

		if (verificaJogador ()) {
			Debug.Log ("Achou o player");
		} 
		else {
			if(!endOfRight){
				moverDireita();
				if(verificaParede(distanciaRay, isRight)){
					endOfRight = true;
					flip (-180);
					isRight = false;
					esperar();
				}
			}
			else {
				moverEsquerda();
				if(verificaParede(distanciaRay, isRight)){
					endOfRight = false;
					flip (180);
					isRight = true;
					esperar();
				}
			}
		}
	}

	private void esperar(){
		tempoEsperando += Time.deltaTime;

		if (tempoEsperando >= tempoEspera) {
			tempoEsperando = 0;
		}
	}

	private bool verificaJogador(){
		Ray rayCast = getRay(isRight);
		RaycastHit hit;

		if(Physics.Raycast(rayCast, out hit, distanciaVisao)){
			if(hit.collider.tag == "Player"){
				player = hit.collider.gameObject;
				return true;
			}
			else {
				return false;
			}
		}
		return false;
	}

}
