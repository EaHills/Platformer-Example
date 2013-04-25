using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public CharacterController characterController;
	
	public float horizontalMovementSpeed = 10f;
	public float gravity = 0.5f;
	
	public Vector3 movement;
	public Vector3 jump;
	
	public bool grounded = true;
	public bool isTrigger = true;

	// Use this for initialization
	void Start () 
	{                
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame 
	void Update ()
    {              
		movement.x = horizontalMovementSpeed * Input.GetAxis("Horizontal");                
        movement.z = 0;
		
		// Used for jumping
		if (grounded == true & isTrigger == true)
		{
			if (grounded == true & Input.GetKeyDown("space"))
			{
				grounded = false;
				movement.y = 10f;

				//yield return WaitForSeconds(2f);
				
				// Debug.Log("space was pressed");	
			}
		}
		// Used for coming back down
		else if (grounded == false)
		{
				movement.y -= gravity * Time.deltaTime;
				if (movement.y <= 0)
				{
					grounded = true;
				    movement.y = -5f;
				}
		}
		
		
		// Ladder interaction
		if (isTrigger)
		{
			// Climbing up
			if (Input.GetAxis ("Vertical") > 0)	
			{
				movement.y = 1f;
				
				transform.Translate (0, 1 * Time.deltaTime, 0);
				
				//Debug.Log ("climbing");
				
				// !!!!! Need to have a single call !!!!!
				if (grounded == false & Input.GetKeyDown("space"))
				{
					movement.y = 10f;

					//yield return WaitForSeconds(2f);
					
					//Debug.Log ("Jumping on/off the ladder");
				}
			}
			// Climbing down
			else if (Input.GetAxis ("Vertical") < 0)
			{
				movement.y = 2f;
				
				transform.Translate (0, -1 * Time.deltaTime, 0);
				
				// !!!!! Need to have a single call !!!!!
				if (grounded == false & Input.GetKeyDown("space"))
				{
					movement.y = 10f;

					//yield return WaitForSeconds(2f);
					
					//Debug.Log ("Jumping on/off the ladder");
				}
			}
			
			// Sitting idle = being on the ladder (having some y), but not moving 
			
			// Sitting idle
			/*
			else if (
			{
				movement.y = 0;
				// Debug.Log ("sitting idle");	
				
				// pasted jumping code - doesn't work :/
				
				// !!!!! Need to have a single call !!!!!
				if (grounded == false & Input.GetKeyDown("space"))
				{
					//grounded = false;
					movement.y = 10f;

					//yield return WaitForSeconds(2f);
					
					//Debug.Log ("Jumping on/off the ladder");
				}
			}
			*/
		}
	
		characterController.Move (movement * Time.deltaTime); 
	}  
	
	// Starting the trigger
	public void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Ladder")
		{
			isTrigger = true;
		}
	}
	
	// Being idle trigger
	public void OnTriggerIdle(Collider c)
	{
		if (c.gameObject.tag == "Ladder")
		{
			isTrigger = true;
		}
	}
	
	// Exiting the trigger
	public void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag == "Ladder")
		{
			isTrigger = false;
		}
	}
}