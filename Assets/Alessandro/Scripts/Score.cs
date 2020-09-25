using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{


    public Text scoreText;

    int score = 0;

   public void AddScore(int _score)
    {
        score += _score;
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
