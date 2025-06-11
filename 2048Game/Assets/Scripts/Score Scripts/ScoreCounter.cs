using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    private ScoreTextView scoreTextView;
    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        scoreTextView = GetComponent<ScoreTextView>();
    }

    private void Start()
    {
        scoreTextView.UpdateScoreText(score);
    }

    public void AddScore(int points)
    {
        score += points;
        scoreTextView.UpdateScoreText(score);
    }

    public void ResetScore()
    {
        score = 0;
        scoreTextView.UpdateScoreText(score);
    }
}
