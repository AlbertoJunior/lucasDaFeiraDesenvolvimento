using UnityEngine;
using System.Collections;

public class Andar : MonoBehaviour {
	
	public float jumpForce = 35f;
	public float moveSpeed = 14f;
	private Animator animacao;
	private bool isRight;
	private Rigidbody rigibody;

	// Use this for initialization
	void Start () {
		rigibody = GetComponent<Rigidbody>();
		animacao = GetComponent<Animator> ();
		isRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D)) {
			if(!isRight){
				flip (-180);
				isRight = true;
			}
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
			//rigibody.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);
			animacao.SetFloat("velocidade", moveSpeed * Time.deltaTime);
		}
		else if (Input.GetKey (KeyCode.A)){
			if(isRight){
				flip (180);
				isRight = false;
			}
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
			//rigibody.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);
			animacao.SetFloat("velocidade", moveSpeed * Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.Space) && !animacao.GetBool("pulando")){
			animacao.SetBool("pulando", true);
			transform.GetComponent<Rigidbody>().AddForce(0, jumpForce * (Time.deltaTime+moveSpeed), 0);
		}
	}
	
	void FixedUpdate(){
		if (animacao.GetFloat("velocidade") > 0.1 && !Input.anyKeyDown) {
			animacao.SetFloat ("velocidade", animacao.GetFloat ("velocidade") - (animacao.GetFloat ("velocidade") * Time.deltaTime));
		}
	}
	
	void OnCollisionEnter (Collision colisors){
		foreach (ContactPoint contact in colisors.contacts) {
			if(contact.otherCollider.gameObject.tag.Equals("Chao")){
				animacao.SetBool("pulando", false);
			}
		}
	}

	private void flip(float val){
		transform.Rotate (0, val, 0);
	}

}
