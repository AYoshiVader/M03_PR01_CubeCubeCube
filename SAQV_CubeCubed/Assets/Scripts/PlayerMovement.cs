using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public Vector3 direction = Vector3.forward;
    public Vector3 strafeDirection = Vector3.right;
    public Vector3 startDirection = Vector3.forward;
    public Vector3 targetDirection = Vector3.forward;
    public float turning = -1f;
    public int turnSide = 0;
    public float turnSpeed = 9f;
    public float speedTransfer;
    public GameManager gameBehaviour;


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(direction * forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(strafeDirection * sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(strafeDirection * -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        turning = turning - 1;
        if (turning > 0)
        {
            TurnSide(turnSide);
        }
    }

    public void TurnHandler(int turnTarget)
    {
        UnityEngine.Debug.Log("Turning " + turnTarget);
        if (turnTarget == 0 || turnTarget == 1)
        {
            TurnSide(turnTarget);
        }
    }

    public void TurnSide(int turnTarget)
    {
        if(turning < 0)
        {
            startDirection = direction;
            turning = 90f/turnSpeed;
            speedTransfer = rb.GetAccumulatedForce().magnitude / turning;
            turnSide = turnTarget;
            targetDirection = Quaternion.AngleAxis(180f * (turnTarget - 0.5f), Vector3.up) * direction;
            UnityEngine.Debug.Log("Vector Values" +  direction);
        }
        UnityEngine.Debug.Log("Turning " + turning + " time(s)");
        UnityEngine.Debug.Log(turnSpeed + " Degrees");
        direction = Quaternion.AngleAxis((2 * turnSpeed) * (turnTarget - 0.5f), Vector3.up) * direction;
        strafeDirection = Quaternion.AngleAxis((2 * turnSpeed) * (turnTarget - 0.5f), Vector3.up) * strafeDirection;
        rb.AddForce((targetDirection - startDirection) * speedTransfer, ForceMode.VelocityChange);
    }
}
