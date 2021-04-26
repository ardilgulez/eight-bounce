using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector] public bool musicEnabled = true;
    [HideInInspector] public bool sfxEnabled = true;

    [HideInInspector] public bool isPaused = false, isFinished = false;
    [HideInInspector] public float score = 0f;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SoundToggleController.Toggle += OnSoundToggle;
        LevelManager.PauseResume += UpdateTimeScale;
        ExplosionController.ExplosionFinished += HandleDeath;
        PlayButtonController.Click += StartPlay;
        MenuButtonController.Click += NavigateToMainMenu;
    }

    private void OnDisable()
    {
        SoundToggleController.Toggle -= OnSoundToggle;
        LevelManager.PauseResume -= UpdateTimeScale;
        ExplosionController.ExplosionFinished -= HandleDeath;
        PlayButtonController.Click -= StartPlay;
        MenuButtonController.Click -= NavigateToMainMenu;
    }

    private void HandleDeath()
    {
        isFinished = true;
        Time.timeScale = 0f;
    }

    public void OnSoundToggle(SoundType type, bool enabled)
    {
        musicEnabled = type == SoundType.Music ? enabled : musicEnabled;
        sfxEnabled = type == SoundType.SFX ? enabled : sfxEnabled;
    }

    public bool GetSoundEnabled(SoundType soundType)
    {
        return soundType == SoundType.Music ? musicEnabled : sfxEnabled;
    }

    public void StartPlay()
    {
        isFinished = false;
        isPaused = false;
        Time.timeScale = 1.0f;
        score = 0;
        SceneManager.LoadScene("Gameplay");
    }

    public void NavigateToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void UpdateTimeScale()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
