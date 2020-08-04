using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
   
    TextMeshProUGUI tmpGui;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        tmpGui = GetComponent<TextMeshProUGUI>();
        tmpGui.text = score.ToString();
    }

  

    public void ScoreHit(int hitPoint)
    {
        score += hitPoint;
        tmpGui.text = score.ToString();
    }
}
