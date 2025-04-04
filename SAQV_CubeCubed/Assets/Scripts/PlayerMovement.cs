using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody scoreKeeper;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public Vector3 direction = Vector3.forward;
    public Vector3 strafeDirection = Vector3.right;
    public Vector3 startDirection = Vector3.forward;
    public Vector3 targetDirection = Vector3.forward;
    public float turning = 0f;
    public int turnSide = 0;
    public float turnSpeed = 9f;
    public float speedTransfer;


    private void Start()
    {
        direction = Vector3.forward;
        strafeDirection = Vector3.right;
        turning = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(direction * forwardForce * Time.deltaTime);
        scoreKeeper.AddForce(Vector3.forward * forwardForce * Time.deltaTime);

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
        turning = turning - 1f;
        if (turning > 0)
        {
            if (turnSide >= 0 && turnSide <= 3)
            {
                TurnSide(turnSide);
            }
        }
    }

    public void TurnHandler(int turnTarget)
    {
        UnityEngine.Debug.Log("Turning " + turnTarget);
        if (turnTarget == 0 || turnTarget == 1)
        {
            TurnSide(turnTarget);
        }
        else if (turnTarget == 2 || turnTarget == 3)
        {
            TurnZ(turnTarget);
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

    public void TurnZ(int turnTarget)
    {
        if(turning < 0)
        {
            startDirection = direction;
            turning = 90f / turnSpeed;
        }
        UnityEngine.Debug.Log("Turning to the Y Axis, currently obsolete");
    }
}
