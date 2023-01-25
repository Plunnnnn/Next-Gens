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
    { coinText.text = "COINS :" + currentCoins.ToString(); }

    public void IncreaseCoins()
    { 
        currentCoins += 1;
        coinText.text = "Coins : " + currentCoins.ToString();
    }
}
