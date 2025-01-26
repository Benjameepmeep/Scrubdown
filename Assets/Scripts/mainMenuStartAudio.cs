using FMODUnity;
using UnityEngine;

public class mainMenuStartAudio : MonoBehaviour
{
    [SerializeField] private EventReference mainMenue;
    private void Start()
    {
        AudioManager.Instance.PlayOneShot(mainMenue, this.transform.position);
    }
    
}
