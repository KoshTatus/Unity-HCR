using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayDistanceText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private Transform playerTrans;
    [SerializeField] private TextMeshProUGUI recordDistance;

    private float distance;
    private int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (sceneIndex)
        {
            case 1:
                bestPoints.bestDistance = bestPoints.bestDistanceCountrySideJeep;
                break;
            case 2:
                bestPoints.bestDistance = bestPoints.bestDistanceCountrySideBike;
                break;
            case 3:
                bestPoints.bestDistance = bestPoints.bestDistanceMoonBike;
                break;
            case 4:
                bestPoints.bestDistance = bestPoints.bestDistanceMoonJeep;
                break;
        }
        distance = playerTrans.position.x;
    }

    private void Update()
    {
        distance = Mathf.Max(playerTrans.position.x, distance);
        bestPoints.bestDistance = Mathf.Max(bestPoints.bestDistance, distance);
        distanceText.text = distance.ToString("F0");
        recordDistance.text = "Best: " + bestPoints.bestDistance.ToString("F0");
    }
}
