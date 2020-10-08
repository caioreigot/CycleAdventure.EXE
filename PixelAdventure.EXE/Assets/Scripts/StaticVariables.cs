using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    private static int totalScore;

    public static int TotalScore
    {
        get
        {
            return totalScore;
        }
        set
        {
            totalScore = value;
        }
    }
}
