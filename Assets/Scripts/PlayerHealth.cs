using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 100;

    public void healthChange(int change) {
        health += change;
        Debug.Log(health);
    }
}
