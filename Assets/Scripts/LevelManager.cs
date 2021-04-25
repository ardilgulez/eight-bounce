using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Text text;

    public float spawnInterval = 1f;
    public float difficultyInterval = 5f;
    public float difficultyModifier = 0.01f;
    private float difficultyTimer = 0f;
    private float spawnTimer = 0f;
    private float spawnHeight = -2f;

    private float score = 0f;

    public delegate void PauseToggle();
    public static event PauseToggle PauseResume;

    // Start is called before the first frame update
    void Start()
    {
        spawnHeight = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        HandlePause();
        UpdateScore();
        UpdateDifficulty();
        HandleSpawn();
    }

    private void HandlePause()
    {
        bool pauseToggle = Input.GetKeyDown(KeyCode.Escape);
        if (pauseToggle)
        {
            PauseResume();
        }
    }

    public void OnClickResumeButton()
    {
        PauseResume();
    }

    private void UpdateScore()
    {
        score += Time.deltaTime;
        text.text = string.Format("{0:N1}", score);
    }

    private void UpdateDifficulty()
    {
        difficultyTimer += Time.deltaTime;
        if (difficultyTimer >= difficultyInterval)
        {
            difficultyTimer = 0;
            spawnInterval -= difficultyModifier;
        }
    }

    private void HandleSpawn()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0;
            float xVal = UnityEngine.Random.Range(-1.5f, 1.5f);
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(xVal, spawnHeight, 0), Quaternion.identity);
            enemy.transform.parent = gameObject.transform.parent;
        }
    }
}
