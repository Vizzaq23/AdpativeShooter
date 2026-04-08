using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Camera playerCamera;
    public float shootDistance = 100f;
    public PerformanceTracker tracker;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tracker.RegisterShot();
            Shoot();

            Debug.Log("Accuracy: " + tracker.GetAccuracy() + "%");
            Debug.Log("Average Reaction Time: " + tracker.GetAverageReactionTime() + " seconds");
        }
    }

    void Shoot()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, shootDistance))
        {
            Target target = hit.collider.GetComponent<Target>();

            if (target != null)
            {
                tracker.RegisterHit();
                target.Hit(tracker);
            }
        }
    }
}