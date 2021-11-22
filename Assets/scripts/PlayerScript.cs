using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public CharacterController controller;
    public float runSpeed = 100f;
    public float moveSpeed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
	float xAxis = 0f;
	float zAxis = 0f;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		if (isGrounded) {
			xAxis = Input.GetAxis("Horizontal");
			zAxis = Input.GetAxis("Vertical");
		}
        move = transform.right * xAxis + transform.forward * zAxis;

        if(Input.GetButton("Fire3")) {
            controller.Move(move * moveSpeed * Time.deltaTime * runSpeed);
        } else {
            controller.Move(move * moveSpeed * Time.deltaTime);
        }


		if (Input.GetButtonDown("Jump") && isGrounded) {
			Debug.Log("moi");
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
		
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
		
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}   