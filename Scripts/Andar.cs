using UnityEngine;
using System.Collections;

public class Andar : Movimentavel {
	private Animator animacao;
	private CameraMover scriptCamera;
	private bool isRight;

	// Use this for initialization
	private void Start () {
		base.Start();
		animacao = GetComponent<Animator> ();
		scriptCamera = (CameraMover) GameObject.FindGameObjectWithTag("MainCamera").GetComponent("CameraMover");
		isRight = true;
	}

	// Update is called once per frame
	private void Update () {
		Ray2D rayCast2 = new Ray2D(transform.position, Vector2.right);
		Debug.DrawRay (rayCast2.origin, rayCast2.direction, Color.red);

		//verificando tecla para movimentar
		if (Input.GetKey (KeyCode.D)) {
			if(!isRight){
				flip (-180);
				isRight = !isRight;
				scriptCamera.flip ();
			}
	
			//verifica se pode movimentar
			if(!verificaParede(distanciaRay, isRight)){
				moverDireita();
				animacao.SetFloat("velocidade", moveSpeed * Time.deltaTime);
			}
		}
		else if (Input.GetKey (KeyCode.A)){
			if(isRight){
				flip (180);
				isRight = !isRight;
				scriptCamera.flip();
			}

			//verifica se pode movimentar
			if(!verificaParede(distanciaRay, isRight)){
				moverEsquerda();
				animacao.SetFloat("velocidade", moveSpeed * Time.deltaTime);
			}
		}

		if(Input.GetKey(KeyCode.Space) && !animacao.GetBool("pulando")){
			animacao.SetBool("pulando", true);
			pular();
		}
	}

	//metodo que verifica se o player colidiu com o chao
	void OnCollisionEnter (Collision colisors){
		foreach (ContactPoint contact in colisors.contacts) {
			if(contact.otherCollider.gameObject.tag.Equals("Chao")){
				animacao.SetBool("pulando", false);
			}
		}
	}
}
