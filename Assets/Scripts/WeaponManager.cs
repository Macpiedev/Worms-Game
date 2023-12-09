using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    public Transform bulletTransform;
    public List<GameObject> bullets = new List<GameObject>();
    private bool isTurn = false;
    private GameObject chosenBullet;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        foreach (GameObject bullet in bullets) {
            bullet.SetActive(false);
        }
    }

    void Update()
    {
        if(isTurn) {
            float playerAndCamPosDiffZ = transform.position.z - mainCamera.transform.position.z;
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * playerAndCamPosDiffZ);
            
            Vector3 rotation = mousePos - transform.position;

            float rotZ = Mathf.Atan2(rotation.y,  rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }

    public void setTurn(bool value) {
        chosenBullet = null;
        isTurn = value;
    }

    public void shoot(int destroyDelay) {
        if(chosenBullet != null) {
            chosenBullet.SetActive(false);
            GameObject newBullet = Instantiate(chosenBullet, bulletTransform.position, Quaternion.identity);
            newBullet.SetActive(true);
            newBullet.GetComponent<IWeapon>().activate(destroyDelay);
        }
    }

    public void changeWeapon(int weaponId) {
        if(chosenBullet != null) {
            chosenBullet.SetActive(false);
        }

        chosenBullet = bullets[weaponId];
        chosenBullet.SetActive(true);
    }

}
