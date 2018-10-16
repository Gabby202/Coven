using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float inputH;
	private float inputV;
	private float moveX;
	private float moveZ;
	public float moveSpeed;
	private Rigidbody rigidbody;
	private Animator animator;
	private bool isRunning;
	private bool isJumping;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftShift)) 
		{
			isRunning = true;
			moveSpeed *= 4f;
		} 
		if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			isRunning = false;
			moveSpeed *= 0.25f;
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			isJumping = true;
		} else {
			isJumping = false;
		}

		inputH = Input.GetAxisRaw("Horizontal");
		inputV = Input.GetAxisRaw("Vertical");

		animator.SetFloat("inputH", inputH);
		animator.SetFloat("inputV", inputV);
		animator.SetBool("isRunning", isRunning);
		animator.SetBool ("isJumping", isJumping);

		moveX = inputH * moveSpeed * Time.deltaTime;
		moveZ = inputV * moveSpeed * Time.deltaTime;

		if(moveZ == 0f) 
		{
			moveX = 0f;
		}

		rigidbody.velocity = new Vector3(moveX, 0f, moveZ);

	}
}
