using System;
using UnityEngine;

public class Scrubing : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 worldMousePos;
    private Vector3 direction;

    private SpriteRenderer _spriteRenderer;

    private float alphaValue = 1;
    
    void Start()
    {
        
        
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        worldMousePos.z = 0;

        transform.position = new Vector3(worldMousePos.x, worldMousePos.y, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("dirt"))
        {
            SpriteRenderer _spriteRenderer = other.GetComponent<SpriteRenderer>();
            
            Color color = _spriteRenderer.color;
            color.a = alphaValue;
            _spriteRenderer.color = color;

            if (alphaValue == 0)
            {
                Destroy(other);
            }
            alphaValue -= 0.2f;
        }
    }
}
