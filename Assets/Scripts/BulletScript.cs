using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : IWeapon
{
    public GameObject explosionEffect;
    private Vector3 mousePos;
    private Camera mainCamera;
    private Rigidbody rigidBody;
    public float force = 15f;
    public float explosionForce = 50f;
    public int damage = 10;
    public float radius = 5f;
    public bool isChosen = false;

    public override void activate(int destroyDelay) {
        Collider capsuleCollider = GetComponent<Collider>();

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

    void destroy() 
    {
        var effect = Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null) {
                Debug.Log(nearbyObject.gameObject.tag);
                rb.AddExplosionForce(explosionForce, transform.position, radius, 0f, ForceMode.Impulse);
            }
        }
        Destroy(effect , 1.0f);
        Destroy(gameObject);
    }

}
