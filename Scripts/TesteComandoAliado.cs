using UnityEngine;
using System.Collections;

public class TesteComandoAliado : MonoBehaviour {
	public enum Estado {Parado, Indo, Voltando}
	public Estado estadoAtual;
	public bool ativado;
	public GameObject alvo;

	public GameObject[] texto;
	public int tempoMensagem;

	private Vector3 posInicial;
	private float tempoMensagemAtual;
	private bool textoAtivo;

	// Use this for initialization
	void Start () {
		posInicial = transform.position;
		tempoMensagemAtual = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//se lucas ja ativou o aliado
		if (ativado) {
			//definindo estados
			if (Input.GetKeyDown (KeyCode.K)) {
				switch (estadoAtual) {
					case Estado.Indo:
						mudaEstado(Estado.Voltando);
						break;
						
					//case Estado.Parado:
					//	mudaEstado(Estado.Indo);
					//	break;
						
					case Estado.Voltando: 
						mudaEstado(Estado.Parado);
						break;
				}
			}
			else if (Input.GetKeyDown (KeyCode.J)) {
				switch (estadoAtual) {
					case Estado.Parado:
						mudaEstado(Estado.Indo);
						break;
				}
			}
		}

		//extecutando estados
		switch (estadoAtual) {
			case Estado.Indo:
				estadoIndo();
				break;

			case Estado.Parado:
			break;

			case Estado.Voltando: 
				estadoVoltando();
				break;
		}
	}

	private void estadoVoltando(){
		transform.position = Vector3.Lerp (transform.position, posInicial, Time.deltaTime); 
		//voltou pra posicao inicial
		if (posInicial.x == transform.position.x+2 || posInicial.x == transform.position.x-2) {
			estadoAtual = Estado.Parado;
		}
	}

	private void estadoIndo(){
		//pega a posicao do alvo
		Vector3 nestaDirecao = alvo.transform.position;
		transform.position = Vector3.Lerp (transform.position, nestaDirecao, Time.deltaTime); 
	}

	public void mudaEstado(Estado estado){
		estadoAtual = estado;
	}









	//TODO so posso usar isso quando fizer o YIELD pra nao travar
	private void escondeTexto(GameObject texto){
		tempoMensagemAtual += Time.deltaTime;
		if(tempoMensagemAtual >= tempoMensagem){
			tempoMensagemAtual = 0;
			texto.SetActive(false);
		}
	}

	void LateUpdate(){
		//desligando a mensagem
		if (textoAtivo) {
			tempoMensagemAtual += Time.deltaTime;
			if(tempoMensagemAtual >= tempoMensagem){
				tempoMensagemAtual = 0;
				foreach (GameObject auxTexto in texto){
					auxTexto.SetActive(false);
				}
				textoAtivo = false;
			}
		}
	}

	//se lucas estiver na area que possa se comunicar pode ativar
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Player")) {
			if(!ativado){
				texto[0].SetActive(true);
				textoAtivo = true;
			}
		} 
		else if (other.gameObject.tag.Equals ("Inimigo") && alvo != null) {
			alvo = other.gameObject;
		} 
		else if (other.gameObject.Equals (alvo)) {
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag.Equals ("Player")) {
			if (Input.GetKeyDown (KeyCode.K)) {
				if(!ativado){
					texto[1].SetActive(true);
					textoAtivo = true;
					ativado = true;
				}
				else {
					texto[2].SetActive(true);
					textoAtivo = true;
				}
			}
		} 
		else if (other.gameObject.tag.Equals ("Inimigo") && alvo != null) {
			alvo = other.gameObject;
		} 
		else if (other.gameObject.Equals (alvo)) {
		}
	}

	private void sinalizaAlvo(){
		if (alvo != null) {

		}
	}
}
