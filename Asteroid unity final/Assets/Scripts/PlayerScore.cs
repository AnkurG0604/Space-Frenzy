using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] Text scoreField;

    public int score = 0;

    void Update()
    {
        scoreField.text = score.ToString();
    }
}
