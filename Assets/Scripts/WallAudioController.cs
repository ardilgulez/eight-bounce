using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAudioController : MonoBehaviour
{
    private string PLAYER_TAG = "Player";
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG) && GameManager.instance.sfxEnabled)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
