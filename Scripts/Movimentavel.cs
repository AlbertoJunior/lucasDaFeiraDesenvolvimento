using UnityEngine;
using System.Collections;

public abstract class Movimentavel : MonoBehaviour{
	public float jumpForce;
	public float moveSpeed;
	public float maxMoveSpeed;
	public float distanciaRay;

	protected Rigidbody rigibody;

	public void Start(){
		rigibody = GetComponent<Rigidbody>();
	}

	protected void moverDireita(){
		rigibody.AddForce (Vector3.forward * moveSpeed, ForceMode.Acceleration);
		if (rigibody.velocity.z > maxMoveSpeed) {
			rigibody.velocity = new Vector3(rigibody.velocity.x, rigibody.velocity.y, maxMoveSpeed);
		}
	}

	protected void moverEsquerda(){
		rigibody.AddForce (Vector3.back * moveSpeed, ForceMode.Acceleration);
		if (rigibody.velocity.z > maxMoveSpeed) {
			rigibody.velocity = new Vector3(rigibody.velocity.x, rigibody.velocity.y, maxMoveSpeed);
		}
	}

	protected void pular(){
		rigibody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
	}
	
	protected void flip(float val){
		transform.Rotate (0, val, 0);
	}

	protected bool verificaParede(float distanciaRay, bool isRight){
		Ray rayCast = getRay (isRight);
		RaycastHit hit;
		
		if(Physics.Raycast(rayCast, out hit, distanciaRay)){
			if(hit.collider.tag == "Colisor"){
				return true;
			}
			else {
				return false;
			}
		}
		return false;
	}

	protected Ray getRay(bool isRight){
		if (isRight) 
			return new Ray (transform.position, Vector3.forward);
		else 
			return new Ray (transform.position, Vector3.back);
	}
}
