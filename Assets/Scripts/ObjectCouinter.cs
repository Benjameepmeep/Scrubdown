using UnityEngine;
public class ObjectCouinter : MonoBehaviour
{
    public static int objectCounter;
    
    void Update()
    {
        if (objectCounter == 0)
        {
            print("clean");
        }
    }
}
