using UnityEngine;

public class TurnControllerBehaviour : MonoBehaviour
{
    public int turnerID = 0; //0 is left, 1 is right, 2 is up, 3 is down
    public GameManager gameManager;

    public void Initialize()
    {
        gameManager = GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.SendMessage("Turner", turnerID);
    }
}
