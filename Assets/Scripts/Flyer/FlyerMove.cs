using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerMove : MonoBehaviour {

    Rigidbody rb;
    public float speed;
    public float torque;

    private bool isColliding = false;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        FlyerControls();

    }

    //Object Still rotates slightly after bouncing off an object
    void FlyerControls()
    {
        #region FORWARD/SIDE MOVEMENT

        if (Input.GetKey(KeyCode.W))
        {
            //move forward
            rb.AddForce(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //move Back
            rb.AddForce((transform.forward*-1) * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //strafe left
            rb.AddForce((transform.right*-1) * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //strafe Right
            rb.AddForce(transform.right * speed);
        }
        #endregion

        #region UP/DOWN TURNING
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //move up
            rb.AddForce(transform.up * speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //move down
            rb.AddForce((transform.up *-1) * speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //turn right
            rb.AddTorque(transform.up * torque);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //turn right
            rb.AddTorque(transform.up * (torque*-1));
        }
        #endregion

        if (isColliding)
        {
            rb.freezeRotation = true;
        }
        else
        {
            rb.freezeRotation = false;
        }
    }


    void OnCollisionEnter(Collision col)
    {
        isColliding = true;
    }

    void OnCollisionExit(Collision col)
    {
        isColliding = false;
    }
}
