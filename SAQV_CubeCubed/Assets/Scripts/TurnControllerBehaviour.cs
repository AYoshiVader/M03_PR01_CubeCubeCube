using System;
using UnityEngine;

public class TurnControllerBehaviour : MonoBehaviour
{
    public int turnerID = 0; //0 is left, 1 is right, 2 is up, 3 is down
    public bool triggered = false;
    public GameManager gameManager;
    public PlayerMovement player;
    
    void OnTriggerEnter(Collider collider)
    {
        if (!triggered && collider.name.Equals("Player"));
        {
            player.TurnHandler(turnerID);
            triggered = true;
        }
    }
}
