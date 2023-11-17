using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public bool canFire = true;
    private float timer;
    public float timeBetweenFiring;

    void Update() {
        if(Input.GetKey("d"))
        {
            playerManager.move(Move.Right);
        }
        
        if(Input.GetKey("a"))
        {
            playerManager.move(Move.Left);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            playerManager.move(Move.Jump);
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
    }
}
