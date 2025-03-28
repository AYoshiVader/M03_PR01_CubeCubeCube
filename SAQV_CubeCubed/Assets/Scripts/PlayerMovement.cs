using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float turning = -1f;
    public int turnSide = 0;
    public float turnSpeed = 3f;
    public GameManager gameBehaviour;

    public void Initialize()
    {
        
        gameBehaviour.TurningTime += TurnHandler;

    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        if (turning > 0)
        {
            TurnSide(turnSide);
        }
        turning = turning - 1;
    }

    public void TurnHandler(int turnTarget)
    {
        UnityEngine.Debug.Log("Turning");
        if (turnTarget == 0 || turnTarget == 1)
        {
            TurnSide(turnTarget);
        }
    }

    public void TurnSide(int turnTarget)
    {
        if(turning < 0)
        {
            turning = 90f/turnSpeed;
            turnSide = turnTarget;
        }
        if(turnTarget == 0)
        {
            rb.MoveRotation(new Quaternion(rb.transform.rotation.x, rb.transform.rotation.y + turnSpeed, rb.transform.rotation.z, rb.transform.rotation.w));
        }
        if (turnTarget == 1)
        {
            rb.MoveRotation(new Quaternion(rb.transform.rotation.x, rb.transform.rotation.y - turnSpeed, rb.transform.rotation.z, rb.transform.rotation.w));
        }
    }
}
