using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{
    GameObject goldScoreObj;
    TMP_Text goldScoreText;
    int score = 0;

    void Awake()
    {
        goldScoreObj = GameObject.FindGameObjectWithTag("GoldScore");
        if (goldScoreObj != null)
        {
            goldScoreText = goldScoreObj.GetComponent<TMP_Text>();
            if (goldScoreText != null)
            {
                Debug.Log("Found GoldScore TextMeshPro component.");
                goldScoreText.SetText("Gold x " + score);
            }
            else
            {
                Debug.LogError("GoldScore object does not have a TextMeshPro component.");
            }
        }
        else
        {
            Debug.LogError("Could not find GameObject with tag 'GoldScore'.");
        }
    }

    void IncrementGoldScore()
    {
        ++score;
        goldScoreText.SetText("Gold x " + score);
    }

    int GetGoldCount()
    {
        return score;
    }

    string GetGoldScore()
    {
        return "Gold x " + score;
    }
}
