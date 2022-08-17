using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSharedUI : MonoBehaviour
{
    #region Singleton class: GameSharedUI

    public static GameSharedUI Instance;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] TMP_Text[] coinsUIText;
    [SerializeField] TMP_Text[] crownsUIText;



    public void UpdateCoinsUIText()
    {
        for (int i = 0; i < coinsUIText.Length; i++)
        {
            SetCoinsText(coinsUIText[i], GameDataManager.GetCoins());
        }
    }

    public void SetCoinsText(TMP_Text textMesh, int value)
    {
        textMesh.text = value.ToString();
    }
    public void UpdateCrownsUIText()
    {
        for (int i = 0; i < crownsUIText.Length; i++)
        {
            SetCrownsText(crownsUIText[i], GameDataManager.GetCrowns());
        }
    }

    public void SetCrownsText(TMP_Text textMesh, int value)
    {
        textMesh.text = value.ToString();
    }


}
