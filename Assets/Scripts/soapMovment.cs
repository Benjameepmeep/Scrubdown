using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class soapMovment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float launchForce = 10f;
    [SerializeField] private float lineLength = 5f;
    
    /*private LineRenderer _lineRenderer;*/
    private Camera mainCamera;
    
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        /*_lineRenderer.startWidth = 0.1f;
        _lineRenderer.endWidth = 0.1f;
        _lineRenderer.positionCount = 2;*/
    }
    
    
    void Update()
    {
        /*_lineRenderer.SetPosition(0, transform.position); 
        _lineRenderer.SetPosition(1, transform.position + direction * lineLength);*/
        if (Input.GetMouseButtonDown(0))
        {
            Launch();
        }

        rb.linearDamping = Input.GetMouseButton(1) ? 0.5f : 1f;
    }

    void Launch()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        worldMousePos.z = 0;

        Vector2 direction = (worldMousePos - transform.position).normalized;
        
        rb.AddForce(direction * launchForce, ForceMode2D.Impulse);
    }
}
