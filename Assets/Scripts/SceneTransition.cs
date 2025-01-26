using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTransition {
    private static readonly GameObject SpriteGameObject;

    private const float TransitionDuration = 3f;
    public static Camera CurrentCamera;
    
    static SceneTransition() {
        SpriteGameObject = new GameObject {
            transform = {
                position = new Vector3(9999, 9999, 0),
                localScale = new Vector3(10, 10, 1),
            }
        };
        
        var spriteRenderer = SpriteGameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Bubble wall");
        spriteRenderer.sortingOrder = 32760;
    
        Object.DontDestroyOnLoad(SpriteGameObject);
    }
    
    public static void LoadScene(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single) {
        _ = LoadSceneTask(sceneName, loadSceneMode);
    }

    public static async Awaitable LoadSceneTask(string sceneName, LoadSceneMode loadSceneMode) {
        await ShowTransitionScreen(2);
        
        await SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
        
        await HideTransitionScreen(1);
    }
    
    public static async Awaitable ShowTransitionScreen(float duration) {
        var targetPosition = CurrentCamera.transform.position;
        targetPosition.z = 0;
        var startPosition = new Vector3(targetPosition.x, targetPosition.y - 22.5f, targetPosition.z);
        
        Debug.Log($"StartPosition: {startPosition} | TargetPosition: {targetPosition}");
        
        SpriteGameObject.transform.position = startPosition;

        var currentProgress = 0f;
        var cameraPreviousPos = startPosition;
        Vector3 cameraDeltaMovement = Vector3.zero;

        while (currentProgress < duration) {
            await Awaitable.NextFrameAsync();
            currentProgress += Time.unscaledDeltaTime;
            
            cameraDeltaMovement += (cameraPreviousPos - CurrentCamera.transform.position) * Time.unscaledDeltaTime; 

            Debug.Log(currentProgress);
            
            var progress = currentProgress / duration;
            var position = Vector3.Lerp(startPosition, targetPosition, progress) + cameraDeltaMovement;

            Debug.Log(position);
            SpriteGameObject.transform.position = position;

            cameraPreviousPos = CurrentCamera.transform.position;
        }
        
        SpriteGameObject.transform.position = targetPosition;
        
    }
    
    public static async Awaitable HideTransitionScreen(float duration) {
        var startPosition = CurrentCamera.transform.position;
        startPosition.z = 0;
        var targetPosition = new Vector3(startPosition.x, startPosition.y - 22.5f, startPosition.z);
        
        Debug.Log($"StartPosition: {startPosition} | TargetPosition: {targetPosition}");
        
        SpriteGameObject.transform.position = startPosition;

        var currentProgress = 0f;
        var cameraPreviousPos = startPosition;

        while (currentProgress < duration) {
            currentProgress += Time.unscaledDeltaTime;
            
            var cameraDeltaMovement = cameraPreviousPos - CurrentCamera.transform.position; 

            Debug.Log(currentProgress);
            
            var progress = currentProgress / duration;
            var position = Vector3.Lerp(startPosition, targetPosition, progress) + cameraDeltaMovement;

            Debug.Log(position);
            SpriteGameObject.transform.position = position;

            cameraPreviousPos = CurrentCamera.transform.position;
            await Awaitable.NextFrameAsync();
        }
        
        SpriteGameObject.transform.position = new Vector3(999, 999, 0);
        SpriteGameObject.transform.parent = null;
    }
}