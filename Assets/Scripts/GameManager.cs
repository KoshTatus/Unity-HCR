using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject pauseBackGround;
    private bool isPause = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (isPause)
        {
            Time.timeScale = 1f;
            isPause = !isPause;
            pauseBackGround.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            isPause = !isPause;
            pauseBackGround.SetActive(true);
        }
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (sceneIndex)
        {
            case 1:
                bestPoints.bestDistanceCountrySideJeep = bestPoints.bestDistance;   
                break;
            case 2:
                bestPoints.bestDistanceCountrySideBike = bestPoints.bestDistance;
                break;
            case 3:
                bestPoints.bestDistanceMoonBike = bestPoints.bestDistance;
                break;
            case 4:
                bestPoints.bestDistanceMoonJeep = bestPoints.bestDistance;
                break;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
