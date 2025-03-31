using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public PlayerMovement playerDirection;
    public int offset = 5;
    public Vector3 targetDirection = Vector3.back;

    // Update is called once per frame
    void Update()
    {
        targetDirection = playerDirection.direction;
        transform.position = player.position + -targetDirection*offset + Vector3.up;
        transform.LookAt(player.position + Vector3.up);
    }
}
