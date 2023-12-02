using UnityEngine;

public enum Move {
    Left,
    Right,
    Jump,
    Shoot
}

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidBody;
    public Vector3 jump;
    public bool isGrounded;
    
    public float sidewaysForce = 500f;
    public float jumpForce = 2.0f;
    public float moveForce = 5.0f;
    private float moveCounter = 0;
    public float moveLimit = 10.0f;

    void Start(){
        rigidBody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    public void resetMoveCounter() {
        moveCounter = 0;
    }

    public void move(Move movement) {
        moveCounter += moveForce * Time.deltaTime;
        if(moveCounter > moveLimit) {
            return;
        }
        switch(movement)
        {
            case Move.Left:
                transform.Translate(-moveForce* Time.deltaTime,0,0, Space.World);
                break;
            case Move.Right:
                transform.Translate(moveForce* Time.deltaTime,0,0, Space.World);
                break;
            case Move.Jump:
                if(isGrounded) {
                    isGrounded = false;
                    rigidBody.AddForce(jump * jumpForce, ForceMode.Impulse);
                }
                break;
        }
    }

}