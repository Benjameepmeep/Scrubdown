using UnityEngine;
using UnityEngine.UIElements;

public class Tommy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D; 
    [SerializeField] private CapsuleCollider2D capsuleCollider2D;

    [SerializeField] private float initialJump = 100f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float timer = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        UpwardForce(initialJump);
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            timer = 0f;
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            UpwardForce();
        }
    }

    void UpwardForce(float force = 5f)
    {
        rigidbody2D.AddForce(force * Vector2.up, ForceMode2D.Force);
    }
}
