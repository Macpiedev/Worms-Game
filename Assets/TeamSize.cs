using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;

public class TeamSize : MonoBehaviour
{
    public PlayerManager playerManager;

    public TMP_Text textScoreTeam1;
    public TMP_Text textScoreTeam2;

    void Update() {
        textScoreTeam1.text = playerManager.getTeam1Size().ToString();
        textScoreTeam2.text = playerManager.getTeam2Size().ToString();
    }
}
