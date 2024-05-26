using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject levelChanger;
    public GameObject vehicleChanger;
    public GameObject clearPanel;
    private string level;
    
    public void OnClickStart()
    {
        levelChanger.SetActive(true);
    }
    public void OnClickBackLevelChanger()
    {
        levelChanger.SetActive(false);
    }
    public void OnClickBackVehicleChanger()
    {
        vehicleChanger.SetActive(false);
        levelChanger.SetActive(true);
    }
    public void OnClickCounrtySide()
    {
        levelChanger.SetActive(false);
        vehicleChanger.SetActive(true);
        level = "Country Side";
    }
    public void OnClickMoon()
    {
        levelChanger.SetActive(false);
        vehicleChanger.SetActive(true);
        level = "Moon";
    }
    public void OnClickClear()
    {
        clearPanel.SetActive(true);
        bestPoints.bestDistanceCountrySideBike = 0;
        bestPoints.bestDistanceCountrySideJeep = 0;
        bestPoints.bestDistanceMoonBike = 0;
        bestPoints.bestDistanceMoonJeep = 0;
    }
    public void OnClickBackClear()
    {
        clearPanel.SetActive(false);
    }
    public void OnClickJeep()
    {
        if (level == "Country Side")
        {
            SceneManager.LoadScene(1);
        }
        if (level == "Moon")
        {
            SceneManager.LoadScene(4);
        }
    }
    public void OnClickBike()
    {
        if (level == "Country Side")
        {
            SceneManager.LoadScene(2);
        }
        if (level == "Moon")
        {
            SceneManager.LoadScene(3);
        }
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }
}
