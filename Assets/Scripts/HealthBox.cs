using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    public int healUpValue;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player")
        {
            collisionInfo.gameObject.GetComponent<PlayerHealth>().healthChange(healUpValue);
            Destroy(gameObject);
        }
    }
}
