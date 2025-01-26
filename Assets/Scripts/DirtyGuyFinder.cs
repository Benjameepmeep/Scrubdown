using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirtyGuyFinder : MonoBehaviour
{
    [SerializeField] private EventReference oneLiners;

    private soapMovment _soapMovment;
    void Start()
    {
        _soapMovment = GetComponent<soapMovment>();
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("dirt"))
        {
            AudioManager.Instance.PlayOneShot(oneLiners, this.transform.position);
            
            if (SceneManager.GetSceneByName("ScrubDown").isLoaded) return;
            SceneManager.LoadSceneAsync("ScrubDown", LoadSceneMode.Additive);
        }
    }
}

