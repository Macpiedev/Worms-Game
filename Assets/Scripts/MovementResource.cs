using UnityEngine.UI;
using UnityEngine;

public class MovementResource : MonoBehaviour
{
    public Image bar;
    [SerializeField] private PlayerManager playerManager;

    void Update() {
        UpdateBar();
    }

    private void UpdateBar() {
        float fillAmount = (playerManager.getMoveLimit() - playerManager.currentPlayerMoveCounter()) / playerManager.getMoveLimit();
        fillAmount = Mathf.Clamp(fillAmount, 0, 1);
        Debug.Log(fillAmount);
        bar.fillAmount = fillAmount;
    }
}   
