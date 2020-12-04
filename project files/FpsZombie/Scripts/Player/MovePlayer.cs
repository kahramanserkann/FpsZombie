using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    //for mobile
    public Camera camera;


	public int speed=3;
	CharacterController characterController;
    const float gravity = 9.8f;
	// Use this for initialization
	void Start () 
	{
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveCharacter();
	}
	Vector3 moveVector;
	private void MoveCharacter()
	{
        //for android
        //moveVector = new Vector3(SimpleInput.GetAxis("Horizontal") * speed * Time.deltaTime, 0, SimpleInput.GetAxis("Vertical") * speed * Time.deltaTime);

        //for pc
        moveVector = new Vector3 (Input.GetAxis("Horizontal")*speed*Time.deltaTime, 0, Input.GetAxis ("Vertical")*speed*Time.deltaTime);
        moveVector = transform.TransformDirection (moveVector);
        
        if (!characterController.isGrounded)
        {
            moveVector.y -= Time.deltaTime * gravity;

        }
		characterController.Move(moveVector);
	}


}
