using UnityEngine;

public class CloseCallController : Scorable
{
    private string PLAYER_TAG = "Player";

    public float CloseCallScore = 500f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {
            Score(CloseCallScore);
            Destroy(gameObject);
        }
    }
}
