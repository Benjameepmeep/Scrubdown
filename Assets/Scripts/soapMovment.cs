using FMOD.Studio;
using FMODUnity;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class soapMovment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float launchForce = 10f;
    [SerializeField] private float lineLength = 0.5f;
    
    private LineRenderer _lineRenderer;
    private Camera mainCamera;

    private Vector3 mousePos;
    private Vector3 worldMousePos;
    private Vector3 direction;
    
    private bool chargeStart = false;
    
    [SerializeField] private EventReference mainThemme;
    private EventInstance eventInstance;
    void Start()
    {
        eventInstance = RuntimeManager.CreateInstance(mainThemme);
        eventInstance.start();
        
        rb = GetComponent<Rigidbody2D>();
        _lineRenderer = GetComponent<LineRenderer>();
        
        mainCamera = Camera.main;
        
        _lineRenderer.startWidth = 0.1f;
        _lineRenderer.endWidth = 0.1f;
        _lineRenderer.positionCount = 2;
    }
    
    void Update()
    { 
        mousePos = Input.mousePosition;
        worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        worldMousePos.z = 0;
        
        direction = (worldMousePos - transform.position).normalized;
        
        _lineRenderer.SetPosition(0, transform.position); 
        _lineRenderer.SetPosition(1, transform.position + direction * lineLength);
        rb.linearDamping = Input.GetMouseButton(1) ? 0.5f : 1f;

        if (rb.linearVelocity.magnitude > 0.1f ) return;
        
        if (Input.GetMouseButton(0))
        {
            chargeStart = true;
            Charge();
        }
        else if(chargeStart)
        {
            chargeStart = false;
            Launch();
            launchForce = 5f;
            lineLength = 0.5f;
        }
        
        
    }

    void Charge()
    {
        if (!(launchForce < 15f)) return;
        launchForce += 2f * Time.deltaTime;
        lineLength += Time.deltaTime;
    }
    
    void Launch()
    {
        RuntimeManager.StudioSystem.setParameterByName("Has_Shot", 1f);
        
        Vector2 direction = (worldMousePos - transform.position).normalized;
        
        rb.AddForce(direction * launchForce, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-10f,10f));
    }
}
