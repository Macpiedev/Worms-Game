using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public CameraManager cameraManager;
    public bool canFire = true;
    private float timer;
    public float timeBetweenFiring;

    void Update() {

        if(Input.GetKey("d"))
        {
            playerManager.move(PlayerMove.Right);
        }
        
        if(Input.GetKey("a"))
        {
            playerManager.move(PlayerMove.Left);  
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            cameraManager.followPlayer = false;
            cameraManager.move(CameraMove.Right);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            cameraManager.followPlayer = false;
            cameraManager.move(CameraMove.Left);
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            cameraManager.followPlayer = false;
            cameraManager.move(CameraMove.Up);
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            cameraManager.followPlayer = false;
            cameraManager.move(CameraMove.Down);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            playerManager.move(PlayerMove.Jump);
        }

        if(!canFire) {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring) {
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButton(0) && canFire){
            canFire = false;
            playerManager.shoot();
        }

        if(Input.GetKey("f"))
        {
            cameraManager.followPlayer = !cameraManager.followPlayer;
        }
    }
}
