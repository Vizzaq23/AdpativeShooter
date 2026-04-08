using UnityEngine;

public class CrosshairFollow : MonoBehaviour
{
    public Vector3 offset = new Vector3(4f, -2f, 0f);

    void Update()
    {
        transform.position = Input.mousePosition + offset;
    }
}