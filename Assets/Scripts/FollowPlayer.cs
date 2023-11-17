using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public PlayerManager playerManager;
    public Vector3 offset;

    void Update()
    {
        if(playerManager.playersExists()) {
            transform.position = playerManager.currentPlayerPosition() + offset;
        }
    }
}
