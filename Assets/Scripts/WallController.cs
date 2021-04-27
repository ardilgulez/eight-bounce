using UnityEngine;

public class WallController : Scorable
{
    private string PLAYER_TAG = "Player";
    private AudioSource audioSource;
    public float CollisionScore = 50;

    public WallSide side = WallSide.Left;
    private WallSide scoreSide = WallSide.Right;

    public delegate void WallCollisionEvent(WallSide side);
    public static event WallCollisionEvent WallCollision;

    private void OnEnable()
    {
        WallCollision += UpdateScoreSide;
    }

    private void OnDisable()
    {
        WallCollision -= UpdateScoreSide;
    }

    private WallSide ToggleSide(WallSide wallSide)
    {
        return wallSide == WallSide.Left ? WallSide.Right : WallSide.Left;
    }

    private void UpdateScoreSide(WallSide lastSide)
    {
        scoreSide = scoreSide == lastSide ? ToggleSide(lastSide) : lastSide;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {
            if (GameManager.instance.sfxEnabled)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
            if (side == scoreSide)
            {
                Score(CollisionScore);
                WallCollision(side);
            }
        }
    }
}
