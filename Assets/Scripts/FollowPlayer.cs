using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public PlayerManager playerManager;
    public Vector3 offset;

    void Update()
    {
        transform.position = playerManager.currentPlayerPosition() + offset;
    }
}
