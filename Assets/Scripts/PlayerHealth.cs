using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private int health = 100;
    public TMP_Text text;

    void Start() {
        text.text = health.ToString();
    }

    public void healthChange(int change) {
        health += change;
        if(health < 50) {
            text.color = new Color32(255, 23, 22, 255);
        }
        text.text = health.ToString();
    }
}
