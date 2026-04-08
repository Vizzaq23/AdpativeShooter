using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Camera playerCamera;
    public float shootDistance = 100f;
    public RoundManager roundManager;

    void Update()
    {
        if (roundManager == null) return;
        if (!roundManager.roundActive) return;

        if (Input.GetMouseButtonDown(0))
        {
            roundManager.RegisterShot();
            Shoot();
        }
    }

    void Shoot()
    {
        if (playerCamera == null) return;

        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, shootDistance))
        {
            Target target = hit.collider.GetComponent<Target>();

            if (target != null)
            {
                target.Hit();
            }
        }
    }
}