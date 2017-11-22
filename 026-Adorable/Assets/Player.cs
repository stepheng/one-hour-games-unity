using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D rigidbody;
	private int jumpTimer = 0;

	private float distToGround;
	private CapsuleCollider2D collider;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();	
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<CapsuleCollider2D>();				
		distToGround = collider.bounds.extents.y - collider.offset.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (animator) {
			animatorControl();
		}
	}

	void animatorControl() {
		AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
		bool isMelting = animator.GetBool("IsMelting");
		bool isReforming = animator.GetBool("IsReforming");

		if (Input.GetKey(KeyCode.S)) {
			animator.SetBool("IsMelting", true);
			animator.SetBool("IsReforming", false);
		} else {
			animator.SetBool("IsReforming", true);
			animator.SetBool("IsMelting", false);
		}

		if (Input.GetKey(KeyCode.A)) {
			if (isMelting == false) {
				animator.SetBool("IsWalking", true);
				transform.localScale = new Vector3(-1, 1, 1);
				rigidbody.AddForce(Vector2.left * 10);
			}
		} else if (Input.GetKey(KeyCode.D)) {
			if (isMelting == false) {
				animator.SetBool("IsWalking", true);
				transform.localScale = new Vector3(1, 1, 1);
				rigidbody.AddForce(Vector2.right * 10);
			}
		} else {
			animator.SetBool("IsWalking", false);
		}		

		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
			rigidbody.AddForce(Vector2.up * 350);
			jumpTimer = 5;
		}
		if (jumpTimer > 0) {
			jumpTimer--;
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	private bool IsGrounded() {
		Debug.Log("Distance: " + distToGround);
		// return Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.1f, LayerMask.GetMask("Platform"));
		
		RaycastHit2D hit = Physics2D.CapsuleCast(collider.bounds.center, collider.size, collider.direction, 0, Vector2.down, 0.1f, LayerMask.GetMask("Platform"));
		return hit != null && hit.transform != null;
 	}
}
