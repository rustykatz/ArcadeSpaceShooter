using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text highScore;
    public Text LastScore;

    // Use this for initialization
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        LastScore.text = PlayerPrefs.GetInt("LastScore", 0).ToString();

    }

}
