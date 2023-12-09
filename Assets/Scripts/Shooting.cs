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
        chosenBullet = bullets[0];
        foreach (GameObject bullet in bullets) {
            bullet.SetActive(false);
        }
       chosenBullet.SetActive(true);
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
        chosenBullet = bullets[0];
        chosenBullet.SetActive(value);
        isTurn = value;
    }

    public void shoot(int destroyDelay) {
        Debug.Log("Shoot!");
        GameObject newBullet = Instantiate(chosenBullet, bulletTransform.position, Quaternion.identity);
        newBullet.GetComponent<IWeapon>().activate(destroyDelay);
    }

    public void changeWeapon(int weaponId) {
        chosenBullet.SetActive(false);
        chosenBullet = bullets[weaponId];
        chosenBullet.SetActive(true);
    }

}
