using UnityEngine;
using System.Collections;

public class Coletavel : MonoBehaviour {
	public bool coletado;
	public AudioClip somColetou;
	public GameObject[] textoUI;

	public bool bau;

	// Use this for initialization
	void Start () {
		coletado = false;
		textoUI[0].SetActive(false);
		textoUI[1].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag.Equals("Player")) {
			//se nao foi coletado tem interacoes
			if(!coletado){
				//ativa o texto
				textoUI[0].SetActive(true);

				//se apertar o botao proximo interagi
				if(Input.GetKeyDown(KeyCode.K)){
					//se for bau tem que abrir
					if(bau){
						GetComponent<Animator>().SetTrigger("Abrir");
					}
					//marca como coletado
					coletado = true;
					textoUI[0].SetActive(false);
					textoUI[1].SetActive(true);
				}
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag.Equals("Player")) {
			if(!coletado){
				textoUI[0].SetActive(false);
			}
			textoUI[1].SetActive(false);
		}
	}
}
