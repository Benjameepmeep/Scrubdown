using UnityEngine;
using UnityEngine.SceneManagement;

public class DirtyGuyFinder : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("dirt"))
        {
            if (SceneManager.GetSceneByName("ScrubDown").isLoaded) return;
            SceneManager.LoadSceneAsync("ScrubDown", LoadSceneMode.Additive);
        }
    }
}

