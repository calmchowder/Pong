using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    [HideInInspector]
    public float leftScore;
    [HideInInspector]
    public float rightScore;

    public Text leftScoreText;
    public Text rightScoreText;


    public void updateText() {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

}
