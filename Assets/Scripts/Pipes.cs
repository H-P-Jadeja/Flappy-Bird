using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }
}
