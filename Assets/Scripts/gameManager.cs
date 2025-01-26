using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static int caracterCount = 4;
    
    void Update()
    {
        if (caracterCount == 0)
        {
            {
                 SceneManager.LoadSceneAsync("crds");
            }
        }
    }
}