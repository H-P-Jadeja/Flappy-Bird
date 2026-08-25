using UnityEngine;
using UnityEngine.InputSystem;

public class BirdController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    private Rigidbody2D rb;
    public float flapStrength = 100f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        // Get the Rigidbody2D component attached to the Bird
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("AnimateSprite", 0.15f, 0.15f);
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Instantly set upward velocity when Space is pressed
            rb.linearVelocity = new Vector2(0, flapStrength);
        }
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Obstacle "))
    //     {
    //         Debug.Log("hit");
    //         Object.FindAnyObjectByType<GameManager>().GameOver();
    //     }
    //     else if (other.gameObject.CompareTag("Scoring"))
    //     {
    //         Object.FindAnyObjectByType<GameManager>().ScorePoint();
    //     }
    // }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Collided with object: {other.gameObject.name} | Tag: {other.gameObject.tag}");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Triggered by object: {other.gameObject.name} | Tag: {other.gameObject.tag}");
    }
}