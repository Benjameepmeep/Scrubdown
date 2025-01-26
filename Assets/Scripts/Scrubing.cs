using UnityEngine;

public class Scrubing : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 worldMousePos;
    private Vector3 direction;

    void Update()
    {
        mousePos = Input.mousePosition;
        worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        worldMousePos.z = 0;

        transform.position = new Vector3(worldMousePos.x, worldMousePos.y, 0f);
    }
}
