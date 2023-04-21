using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour {
    
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public int pointsPerWord = 10;

    private void Start() {
        score = 0;
    }

    public void UpdateScore() {
        score += pointsPerWord;
        scoreText.text = "Score: " + score.ToString();
    }

}
