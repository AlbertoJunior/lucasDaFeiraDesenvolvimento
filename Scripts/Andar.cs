using UnityEngine;
using System.Collections;

public class Andar : MonoBehaviour {
	
	public float jumpForce;
	public float moveSpeed;
	public float distanciaRay;

	private Animator animacao;
	private bool isRight;
	private Ray rayCast;

	// Use this for initialization
	void Start () {
		//rigibody = GetComponent<Rigidbody>();
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

			if(verificaParede()){
				transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
				animacao.SetFloat("velocidade", moveSpeed * Time.deltaTime);
			}
		}
		else if (Input.GetKey (KeyCode.A)){
			if(isRight){
				flip (180);
				isRight = false;
			}

			if(verificaParede()){
				transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
				animacao.SetFloat("velocidade", moveSpeed * Time.deltaTime);
			}
		}

		if(Input.GetKey(KeyCode.Space) && !animacao.GetBool("pulando")){
			animacao.SetBool("pulando", true);
			transform.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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

	private bool verificaParede(){
		RaycastHit hit;

		if (isRight) 
			rayCast = new Ray (transform.position, Vector3.forward);
		else 
			rayCast = new Ray (transform.position, Vector3.back);

		if(Physics.Raycast(rayCast, out hit, distanciaRay)){
			if(hit.collider.tag == "Colisor"){
				return false;
			}
			else {
				return true;
			}
		}
		return true;
	}

}
