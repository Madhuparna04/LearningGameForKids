using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
	public float speed = 10;
	float rotSpeed = 80;
	float gravity = 8;
	float rot=0;
	Vector3 moveDir = Vector3.zero;
	CharacterController controller;
	Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded)
		{
			if(Input.GetKey("w"))
			{
				anim.SetInteger("condition",1);
				moveDir = new Vector3(0,0,1);
				moveDir *= speed;
				moveDir = transform.TransformDirection(moveDir);
			}
			if(Input.GetKeyUp("w"))
			{
				anim.SetInteger("condition",0);
				moveDir = new Vector3(0,0,0);
			}



			if(Input.GetKey("s"))
			{
				anim.SetInteger("condition",1);
				moveDir = new Vector3(0,0,-1);
				moveDir *= speed;
				moveDir = transform.TransformDirection(moveDir);
			}
			if(Input.GetKeyUp("s"))
			{
				anim.SetInteger("condition",0);
				moveDir = new Vector3(0,0,0);
			}


			if(Input.GetKey("d"))
			{
				anim.SetInteger("condition",1);
				moveDir = new Vector3(1,0,0);
				moveDir *= speed;
				moveDir = transform.TransformDirection(moveDir);
			}
			if(Input.GetKeyUp("d"))
			{
				anim.SetInteger("condition",0);
				moveDir = new Vector3(0,0,0);
			}


			if(Input.GetKey("a"))
			{
				anim.SetInteger("condition",1);
				moveDir = new Vector3(-1,0,0);
				moveDir *= speed;
				moveDir = transform.TransformDirection(moveDir);
			}
			if(Input.GetKeyUp("a"))
			{
				anim.SetInteger("condition",0);
				moveDir = new Vector3(0,0,0);
			}
			rot +=Input.GetAxis("Horizontal")*rotSpeed*Time.deltaTime;
			transform.eulerAngles = new Vector3(0,rot,0);

			moveDir.y -= gravity*Time.deltaTime;
			controller.Move(moveDir*Time.deltaTime);
   	 	}
	}
}
