using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ChangePlayerDelegate();

public abstract class IWeapon : MonoBehaviour
{
    public abstract IEnumerator activate(ChangePlayerDelegate postAttackCallback);
    public abstract int damage();

    protected CameraManager cameraManager;

    public void Start() {
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");

        cameraManager = cameraObject.GetComponent<CameraManager>();
    }

    public void Update() {  
        cameraManager.setW(gameObject.transform.position);
    }
}
