using UnityEngine;

public class SmellLineControler : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public Sprite sparkle1, sparkle2;

    private int randonNum;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        randonNum = Mathf.RoundToInt(Random.Range(0,1));
    }

    void Update()
    {
        if (ObjectCouinter.objectCounter != 0) return;
        if (randonNum == 1)
        {
            _spriteRenderer.sprite = sparkle1;
        }
        else
        {
            _spriteRenderer.sprite = sparkle2;
        }
    }
}
