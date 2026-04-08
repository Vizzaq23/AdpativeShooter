using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 1.5f;

    private Vector3 startPosition;
    private int movementType;

    void Start()
    {
        startPosition = transform.position;

        // 0 = no movement, 1 = left/right, 2 = up/down
        movementType = Random.Range(0, 3);
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        if (movementType == 1)
        {
            transform.position = startPosition + new Vector3(offset, 0f, 0f);
        }
        else if (movementType == 2)
        {
            transform.position = startPosition + new Vector3(0f, offset, 0f);
        }
    }
}