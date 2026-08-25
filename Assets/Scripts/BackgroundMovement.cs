using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake(){
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}

