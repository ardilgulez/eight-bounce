using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelVisibilityController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pausePanel, inGamePanel, gameplayElements, endGamePanel;

    private void OnEnable()
    {
        LevelManager.PauseResume += TogglePanelVisibility;
        ExplosionController.ExplosionFinished += HandlePlayerDeath;
    }

    private void OnDisable()
    {
        LevelManager.PauseResume -= TogglePanelVisibility;
        ExplosionController.ExplosionFinished -= HandlePlayerDeath;
    }

    private void TogglePanelVisibility()
    {
        pausePanel.SetActive(GameManager.instance.isPaused);
        inGamePanel.SetActive(!GameManager.instance.isPaused);
        gameplayElements.SetActive(!GameManager.instance.isPaused);
    }

    private void HandlePlayerDeath()
    {
        pausePanel.SetActive(false);
        inGamePanel.SetActive(false);
        gameplayElements.SetActive(false);
        endGamePanel.SetActive(true);
    }
}
