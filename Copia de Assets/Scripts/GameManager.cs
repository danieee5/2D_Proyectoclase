using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI textScore;

    public void AddScore()
    {
        score++;
        textScore.text = "S c o r e : " + score.ToString();
    }
}
