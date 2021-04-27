using UnityEngine;

public class Enemy : Scorable
{
    private string BOTTOM_TAG = "Bottom";
    public float DodgeScore = 20;

    public GameObject explosion;

    private void OnEnable()
    {
        BallMovement.Death += HandleExplosion;
    }

    private void OnDisable()
    {
        BallMovement.Death -= HandleExplosion;
    }

    private void HandleExplosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(BOTTOM_TAG))
        {
            Score(DodgeScore);
            Destroy(gameObject);
        }
    }
}
