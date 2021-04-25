using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 2.5f;
    public float direction = 1f;

    private string WALL_TAG = "Wall";
    private string ENEMY_TAG = "Enemy";

    public delegate void DeathEvent();
    public static event DeathEvent Death;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouse();
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0 , 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(WALL_TAG))
        {
            ReverseDirection();
        } else if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            Death();
        }
    }

    private void HandleMouse()
    {
        if(GameManager.instance.isPaused || !Input.GetButtonDown("Fire1"))
            return;

        if (GameManager.instance.sfxEnabled)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
        ReverseDirection();
    }

    private void ReverseDirection()
    {
        direction *= -1f;
    }
}
