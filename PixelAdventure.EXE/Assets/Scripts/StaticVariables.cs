using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    private static int totalScore;
    private static int amountApplesLevelPast;

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

    public static int AmountApplesLevelPast
    {
        get
        {
            return amountApplesLevelPast;
        }
        set
        {
            amountApplesLevelPast = value;
        }
    }
}
