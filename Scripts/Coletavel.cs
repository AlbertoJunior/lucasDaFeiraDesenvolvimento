using UnityEngine;
using System.Collections;

public class Coletavel : MonoBehaviour {
	public bool coletado;
	public AudioClip somColetou;
	public GameObject textoUI;
	public GameObject textoUIOK;

	public bool bau;

	// Use this for initialization
	void Start () {
		coletado = false;
		textoUI.SetActive(false);
		textoUIOK.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag.Equals("Player")) {
			if(!coletado){
				textoUI.SetActive(true);
				if(Input.GetKeyDown(KeyCode.K)){
					if(bau){
						GetComponent<Animator>().SetTrigger("Abrir");
					}
					coletado = true;
					textoUI.SetActive(false);
					textoUIOK.SetActive(true);
				}
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag.Equals("Player")) {
			if(!coletado){
				textoUI.SetActive(false);
			}
			textoUIOK.SetActive(false);
		}
	}}
