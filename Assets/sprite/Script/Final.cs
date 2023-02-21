using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    Text score;
    string s = Score.scoreValue.ToString();
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Final score: ";
    }
}
