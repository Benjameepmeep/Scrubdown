using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static int caracterCount = 4;
    
    void Update()
    {
        if (caracterCount == 0 && SceneManager.sceneCount <= 2)
        {
            SceneManager.LoadSceneAsync("crds");
        }
    }
}
