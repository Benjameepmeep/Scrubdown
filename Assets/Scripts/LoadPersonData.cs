using UnityEngine;

public class LoadPersonData : MonoBehaviour {
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PersonData personData;
    
    private void Start() {
        spriteRenderer.sprite = personData.sprite;
    }
}