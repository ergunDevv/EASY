using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinPicker : MonoBehaviour
{
    // Start is called before the first frame update



    public PlayerData playerData;



    public bool isColliding;
    public bool isPlayerDead1;
    public BetterJump betterJump;
    [SerializeField] ParticleSystem crownsRewardFx;



    public void Start()
    {


        betterJump= GetComponent<BetterJump>();
        GameSharedUI.Instance.UpdateCoinsUIText();
        GameSharedUI.Instance.UpdateCrownsUIText();


    }
    public void Update()
    {
        isColliding = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (isColliding) return;
        isColliding = true;
        if (other.transform.tag == "Star")
        {

            SoundMangerScript.PlaySound("coinPick");
            GameDataManager.AddCoins();
            if (PlayerPrefs.GetInt("vibrationtoggleplayerpref") == 1)
            {
                Vibrator.Vibrate();
            }

            GameSharedUI.Instance.UpdateCoinsUIText();


            Destroy(other.gameObject);


        }
        if (other.transform.tag == "Crown")
        {
            SoundMangerScript.PlaySound("CrownPick");

            GameDataManager.AddCrowns();

            crownsRewardFx.Play();
            Debug.Log("ergun");

            if (PlayerPrefs.GetInt("vibrationtoggleplayerpref") == 1)
            {
                Vibrator.Vibrate();
            }

            GameSharedUI.Instance.UpdateCrownsUIText();

            isPlayerDead1 = true;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(other.gameObject);


        }
        
    }


}


