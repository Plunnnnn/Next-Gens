using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score1 : MonoBehaviour
{
    public static Score1 instance;

    public TMP_Text coinText;
    public int currentCoins  = 0;

    void Awake()
    { instance = this; }

    void Start()
    { coinText.text = "x " + currentCoins.ToString(); }

    public void IncreaseCoins(int queterec)
    { 
        currentCoins += queterec;
        coinText.text = "x " + currentCoins.ToString();
    }
}
