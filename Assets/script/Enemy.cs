using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private int hitPoints = 10;
    [SerializeField] private int destroyScore = 100;
    [SerializeField] private int hitScore = 10;
    [SerializeField] private Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        ProcessHit();
        scoreboard.AddScore(hitScore);
        
    }

    private void ProcessHit()
    {
        if (hitPoints <= 0)
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            scoreboard.AddScore(destroyScore);
        }
    }
}
