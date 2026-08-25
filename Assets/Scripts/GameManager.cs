using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public void GameOver()
    {
        Debug.Log("Game Over");
    }
    public void ScorePoint()
    {
        score++;
        Debug.Log("Score! Current score: " + score);
    }
}
