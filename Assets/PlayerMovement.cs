using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public CharacterController characterController;
	
	public float horizontalMovementSpeed = 5f;
	public float gravity = 10f;
	
	public Vector3 movement;
	public Vector3 jump;
	

	// Use this for initialization
	void Start () 
	{                
		characterController = GetComponent<CharacterController>();
	}
	
	
	
	// Update is called once per frame 
	void Update ()
    {              
		movement.x = horizontalMovementSpeed * Input.GetAxis("Horizontal");                
		movement.y = -gravity;
        movement.z = 0;
        
		characterController.Move (movement*Time.deltaTime);  
		
		//if (Input.GetKeyDown(jumping));
	}      
}