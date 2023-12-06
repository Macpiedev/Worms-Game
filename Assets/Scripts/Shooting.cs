using UnityEngine.EventSystems;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    public Transform bulletTransform;
    public GameObject bullet;
    private bool isTurn = false;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        bullet.active = false;
    }

    void Update()
    {
        if(isTurn) {
            bullet.active = true;
            float playerAndCamPosDiffZ = transform.position.z - mainCamera.transform.position.z;
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * playerAndCamPosDiffZ);
            
            Vector3 rotation = mousePos - transform.position;

            float rotZ = Mathf.Atan2(rotation.y,  rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }

    public void setTurn(bool value) {
        bullet.active = value;
        isTurn = value;
    }

    public void shoot(int destroyDelay) {
        Debug.Log("Shoot!");
        GameObject newBullet = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        newBullet.GetComponent<BulletScript>().Shoot(destroyDelay);
    }

}
