using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCamera;
    private Rigidbody rigidBody;
    public float force;
    public int damage = 10;

    public void Shoot(int destroyDelay) {
        CapsuleCollider capsuleCollider = GetComponent<CapsuleCollider>();

        if (capsuleCollider != null)
        {
            capsuleCollider.enabled = true;
        }


        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rigidBody = GetComponent<Rigidbody>();

        float playerAndCamPosDiffZ = transform.position.z - mainCamera.transform.position.z;
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * playerAndCamPosDiffZ);
        Vector3 rotation = mousePos - transform.position;
        rigidBody.isKinematic = false;
        rigidBody.velocity = rotation.normalized * force;

        Invoke("destroy", destroyDelay);
    }

    void OnCollisionEnter(Collision collisionInfo) 
    {
        if(collisionInfo.collider.tag == "Player" && !rigidBody.isKinematic)
        {
            destroy();
        }
    }

    void destroy() 
    {
        Destroy(gameObject);
    }

}
