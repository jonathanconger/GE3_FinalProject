using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private MenuAudio menuAudio;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject levelCompleteMenu;
    [SerializeField] private GameObject targetCounter;
    [SerializeField] private TMPro.TextMeshProUGUI counterText;
    [SerializeField] private PlayerController playerController;

    [HideInInspector] public static bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        playerController.enabled = true;
        Time.timeScale = 1;
        isPaused = false;
    }

    private void PauseGame()
    {
        playerController.enabled = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;

        menuAudio.PlaySound("pause");
    }

    public void UpdateTargetCount(int targetCount)
	{
        counterText.text = "Targets: " + targetCount.ToString();
	}

    public void DeactivateCounter()
	{
        targetCounter.SetActive(false);
	}

    public void LevelComplete()
	{
        playerController.enabled = false;
        levelCompleteMenu.SetActive(true);
        levelCompleteMenu.GetComponent<AudioSource>().Play();
	}
}
