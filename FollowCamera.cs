using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 Camera;
    void Update()
    {
        transform.position = new Vector3(
            player.position.x,
            player.position.y,
            Camera.z
            );
    }
}
