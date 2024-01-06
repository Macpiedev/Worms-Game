using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public PlayerManager playerManager;
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
        if(health <= 0) {
            gameObject.SetActive(false);
            
            playerManager.changeTeamSize(gameObject.GetComponent<PlayerInfo>().teamId);

            return;
        }
        text.text = health.ToString();
    }
}
