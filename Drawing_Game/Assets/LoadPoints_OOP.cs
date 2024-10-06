using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadPoints_OOP : MonoBehaviour
{
    public TextMeshProUGUI pointsscored;
    private int currentpoints = Singletonattributes.Instance.pointcounter;

    // Start is called before the first frame update
    void Start()
    {
        pointsscored.text = "Points: " + currentpoints;
    }

}


