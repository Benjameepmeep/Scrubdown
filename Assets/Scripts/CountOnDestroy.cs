using UnityEngine;

public class CountOnDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        gameManager.caracterCount--;
    }
}
