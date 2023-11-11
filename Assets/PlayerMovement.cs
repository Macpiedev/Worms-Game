using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidBody;
    Transform transform;
    public Vector3 jump;
    public bool isGrounded;
    
    public float sidewaysForce = 500f;
    public float jumpForce = 2.0f;
    public float moveForce = 5.0f;

    void Start(){
        rigidBody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    void Update() {
        if(Input.GetKey("right"))
        {
            transform.Translate(moveForce* Time.deltaTime,0,0, Space.World);
        }
        
        if(Input.GetKey("left"))
        {
            transform.Translate(-moveForce* Time.deltaTime,0,0, Space.World);
        }



        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            isGrounded = false;
            rigidBody.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
        Debug.Log(isGrounded);
    }
}