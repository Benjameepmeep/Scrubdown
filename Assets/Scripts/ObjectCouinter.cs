using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCouinter : MonoBehaviour
{
    public static int objectCounter;
    
    void Update()
    {
        if (objectCounter == 0 )
        {
            SceneManager.UnloadSceneAsync("ScrubDown");
            gameManager.caracterCount--;
        }
    }
}
