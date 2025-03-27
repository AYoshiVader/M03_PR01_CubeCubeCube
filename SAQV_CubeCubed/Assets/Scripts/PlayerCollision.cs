using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    string turnTarget = null;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

        if(collisionInfo.collider.tag == "Turner")
        {
            turnTarget = collisionInfo.collider.name;
            UnityEngine.Debug.Log("Turning" + turnTarget);
        }
    }
}
