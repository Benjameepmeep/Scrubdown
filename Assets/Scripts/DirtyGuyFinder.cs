using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirtyGuyFinder : MonoBehaviour {
    [SerializeField] private PersonData personData;
    
    [SerializeField] private EventReference OtherSong;

    public EventInstance eventInstance;
    
    private soapMovment _soapMovment;
    void Start()
    {
        _soapMovment = GetComponent<soapMovment>();

        SceneTransition.CurrentCamera = Camera.main;
    }
    
    void Update()
    {
        if (SceneManager.sceneCount < 2)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("dirt"))
        {
            eventInstance = RuntimeManager.CreateInstance(OtherSong);
            eventInstance.start();

            _soapMovment.eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

            var targetSprite = other.transform.GetComponent<SpriteRenderer>().sprite;
            personData.sprite = targetSprite;
            
            Destroy(other.gameObject);
            
            if (SceneManager.GetSceneByName("ScrubDown").isLoaded) return;
            SceneTransition.LoadScene("ScrubDown", LoadSceneMode.Additive);
        }
    }
    
}

