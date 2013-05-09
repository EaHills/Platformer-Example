using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public CharacterController characterController;
	
	public float horizontalMovementSpeed = 10f;
	public float gravity = -0.5f;
	
	public Vector3 movement;
	public Vector3 jump;
	
	public bool grounded = false;
	public bool isTrigger = false;

	// Use this for initialization
	void Start()
	{                
		isTrigger = false;
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame 
	void Update()
    {              
		moving();
		jumping();
		ladderInteraction();
		
		characterController.Move (movement * Time.deltaTime);
	}  
	
	// Starting the trigger
	public void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Ladder")
		{
			//Debug.Log("isTrigger == true");
			isTrigger = true;
		}
	}
	
	/*
	// Being idle trigger
	public void OnTriggerIdle(Collider c)
	{
		if (c.gameObject.tag == "Ladder")
		{
			isTrigger = true;
		}
	}
	*/
	
	// Exiting the trigger
	public void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag == "Ladder")
		{
			//Debug.Log("isTrigger == false");
			isTrigger = false;
			grounded = false;
		}
	}
	
	public void moving()
	{
		movement.x = horizontalMovementSpeed * Input.GetAxis("Horizontal");                
        movement.z = 0;	 	
	}
		
	// Jumping function
	/*
	public void OnJump()
	{
		if (grounded == false & Input.GetKeyDown("space"))
		{
			movement.y = 10f;

		    //yield return WaitForSeconds(2f);
					
		    Debug.Log ("Jumping on/off the ladder");
		}
	}
	*/
	
	public void jumping()
	{
		// Used for jumping
		if (grounded == true)// || isTrigger == true)
		{
			if (grounded == true & Input.GetKeyDown("space"))
			{
				grounded = false;
				//isTrigger = false;
				movement.y = 10f;

				//yield return WaitForSeconds(2f);
				
				// Debug.Log("space was pressed");	
			}
		}
		// Used for coming back down
		else if (grounded == false)
		{
			movement.y -= gravity * Time.deltaTime;
			//Debug.Log(movement.y);
			if (movement.y <= 0)
			{
				//Debug.Log("AWESOME!!!!!!!");
				grounded = true;
			    movement.y = -5f;
			}
		}	
	}
	
	public void ladderInteraction()
	{
		// Ladder interaction
		if (isTrigger)
		{
			//Debug.Log("Herp derp");
			// Climbing up
			if (Input.GetAxis ("Vertical") > 0)	
			{
				movement.y = 4f;
				
				if (grounded == false & Input.GetKeyDown("space"))
				{
					movement.y = 10f;

					//yield return WaitForSeconds(2f);
					
					//Debug.Log ("Jumping on/off the ladder");
				}
			}
			// Climbing down
			else if (Input.GetAxis ("Vertical") <= 0)
			{
				movement.y = -3f;
				
				if (grounded == false & Input.GetKeyDown("space"))
				{
					//grounded = false;
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
	}
}