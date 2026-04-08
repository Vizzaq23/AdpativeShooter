using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public float spawnTime;
    public float lifetime = 3f;
    public float moveSpeed = 2f;

    private RoundManager roundManager;
    private bool isHit = false;

    void Start()
    {
        roundManager = FindObjectOfType<RoundManager>();

        if (spawnTime <= 0f)
        {
            spawnTime = Time.time;
        }

        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    public void Hit()
    {
        if (isHit) return;
        isHit = true;

        if (roundManager != null && roundManager.roundActive)
        {
            float reactionTime = Time.time - spawnTime;
            roundManager.RegisterHit(reactionTime);

            Debug.Log("Target hit! Reaction Time: " + reactionTime + " seconds");
        }

        StartCoroutine(HitEffect());
    }

    IEnumerator HitEffect()
    {
        Renderer rend = GetComponent<Renderer>();

        if (rend != null)
        {
            rend.material.color = Color.red;
        }

        transform.localScale *= 0.5f;

        yield return new WaitForSeconds(0.08f);

        Destroy(gameObject);
    }
}