using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelVisibilityController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pausePanel, inGamePanel, gameplayElements;

    private void OnEnable()
    {
        LevelManager.PauseResume += TogglePanelVisibility;
    }

    private void OnDisable()
    {
        LevelManager.PauseResume -= TogglePanelVisibility;
    }

    private void TogglePanelVisibility()
    {
        pausePanel.SetActive(GameManager.instance.isPaused);
        inGamePanel.SetActive(!GameManager.instance.isPaused);
        gameplayElements.SetActive(!GameManager.instance.isPaused);
    }
}
