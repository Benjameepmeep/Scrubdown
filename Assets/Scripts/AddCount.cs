using System.Collections.Generic;
using UnityEngine;

public class AddCount : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites; 
    private float alphaValue = 1;
    

    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.sprite = _sprites[Mathf.RoundToInt(Random.Range(0, 5))];
        
        ObjectCouinter.objectCounter++;
    }

    private void OnDestroy()
    {
        ObjectCouinter.objectCounter--;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("soap"))
        {
            Color color = _spriteRenderer.color;
            color.a = alphaValue;
            _spriteRenderer.color = color;

            if (alphaValue <= 0)
            {
                Destroy(this);
            }
            alphaValue -= 0.2f;
        }
    }
}
