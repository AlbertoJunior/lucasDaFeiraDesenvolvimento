using UnityEngine;
using System.Collections;

public class Andar : MonoBehaviour {
	
	public float jumpSpeed = 20f;
	public float rotationSpeed = 13.5f;
	public float moveSpeed = 6.5f;
	public bool recarregando = false;
	private Animator animacao;
	
	// Use this for initialization
	void Start () {
		animacao = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
		}
		else if(Input.GetKey(KeyCode.A)){
			transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
		}
		
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
		}
		else if(Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
			animacao.SetFloat("velocidade", moveSpeed);
		}
		if(Input.GetKey(KeyCode.Space) && !animacao.GetBool("pulando")){
			transform.rigidbody.AddForce(0, jumpSpeed * (Time.deltaTime+10), 0);
			animacao.SetBool("pulando", true);
		}
		if(Input.GetKey(KeyCode.F)){
			animacao.SetTrigger("acenar");
		}
	}
	
	void FixedUpdate(){
		if(animacao.GetFloat("velocidade") > 0.1){
			animacao.SetFloat("velocidade",animacao.GetFloat("velocidade") * -Time.deltaTime);
		}
	}
	
	void OnCollisionEnter (Collision colisors){
		foreach(ContactPoint col in colisors.contacts){
			Debug.DrawRay(col.point, col.normal, Color.white);

			if(col.point.Equals("Coletavel")){
			}
			if(col.otherCollider.CompareTag("Chao")){
				Debug.Log("teste");
				//animacao.SetBool("pulando", false);
			}
		}
	}
}
