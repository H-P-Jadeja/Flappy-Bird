using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;

    public Text scoreText;
    public GameObject gameOver;
    public GameObject playButton;
    public BirdController birdController;

    private Vector3 birdStartPosition; // Stores origin/start position
    private Rigidbody2D birdRb;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (birdController != null)
        {
            // Store original position and Rigidbody2D reference
            birdStartPosition = birdController.transform.position;
            birdRb = birdController.GetComponent<Rigidbody2D>();
        }

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        playButton.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1;

        if (birdController != null)
        {
            // 1. Reset Position back to origin/starting point
            birdController.transform.position = birdStartPosition;

            // 2. Reset Rotation angle to facing forward
            birdController.transform.rotation = Quaternion.identity;

            // 3. Reset Physics Velocity so the bird doesn't instantly fall
            if (birdRb != null)
            {
                birdRb.linearVelocity = Vector2.zero; // Use birdRb.velocity in Unity 2022 and earlier
                birdRb.angularVelocity = 0f;
            }

            birdController.enabled = true;
        }

        // Clear existing pipes from previous run
        Pipes[] pipes = FindObjectsByType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        if (birdController != null)
        {
            birdController.enabled = false;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    public void ScorePoint()
    {
        score++;
        scoreText.text = "Score: " + score;
        Debug.Log("Score! Current score: " + score);
    }
}