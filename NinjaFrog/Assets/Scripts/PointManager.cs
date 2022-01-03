using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    int points;
    [SerializeField]
    private TextMeshProUGUI pointsText;

    private void Start()
    {
        RefreshPointsUI();
    }

    public void AddPoints(int PointsToAdd)
    {
        points += PointsToAdd;
        RefreshPointsUI();
    }

    void RefreshPointsUI()
    {
        pointsText.text = "Points: " + points;
    }

}
