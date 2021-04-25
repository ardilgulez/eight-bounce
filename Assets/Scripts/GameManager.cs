using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool musicEnabled = true;
    public bool sfxEnabled = true;

    [HideInInspector]
    public bool isPaused = false;
    public float score = 0f;

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
    }

    private void OnDisable()
    {
        SoundToggleController.Toggle -= OnSoundToggle;
        LevelManager.PauseResume -= UpdateTimeScale;
    }

    public void OnSoundToggle(SoundType type, bool enabled)
    {
        musicEnabled = type == SoundType.Music ? enabled : musicEnabled;
        sfxEnabled = type == SoundType.SFX ? enabled : sfxEnabled;
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void UpdateTimeScale()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
