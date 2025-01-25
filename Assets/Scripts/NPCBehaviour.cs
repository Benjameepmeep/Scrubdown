using UnityEngine;
using UnityEngine.Serialization;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float timer;
    
    [SerializeField] private bool goingLeft;
    [SerializeField] private bool printEnabled;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
       rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (printEnabled)
        {
            print(timer);
        }
        
        if (goingLeft)
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);
        }
        else if (!goingLeft)
        {
            transform.position += Vector3.right * (speed * Time.deltaTime);
        }
        
        if (3 < timer)
        {
            goingLeft = !goingLeft;
            timer = 0f;
        }
    }
}
