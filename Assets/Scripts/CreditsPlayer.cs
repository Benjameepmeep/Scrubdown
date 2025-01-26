using FMODUnity;
using UnityEngine;

public class CreditsPlayer : MonoBehaviour
{
    [SerializeField] private EventReference CreditsSong;
    void Start()
    {
        AudioManager.Instance.PlayOneShot(CreditsSong, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
