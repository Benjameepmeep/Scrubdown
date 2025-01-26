using System;
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
        SceneManager.LoadSceneAsync("ScrubDown", LoadSceneMode.Additive);
    }
}

