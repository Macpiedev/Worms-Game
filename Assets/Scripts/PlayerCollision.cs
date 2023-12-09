using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerHealth ph;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Missle")
        {
            Debug.Log("Something hit!");
            GameObject collisionObject = collisionInfo.gameObject;

            int damage = -collisionObject.GetComponent<BulletScript>().damage;
            ph.healthChange(damage);
        }
    }
}
