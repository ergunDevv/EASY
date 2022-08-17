using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using DG.Tweening;


public class RewardBox : MonoBehaviour
{
    
    public enum UserRewardType
    {
        Stars,
        Crowns
    }

    [Serializable] public struct UserReward
    {
        public UserRewardType RewardType;
        public Sprite Icon;
        public int Amount;
    }

    [SerializeField] GameObject rewardBoxUICanvas;
    [SerializeField] Transform rewardsParent;
    [SerializeField] Transform rewardsCheckMarksParent;

    [Space]
    [Header("Progress Bar UI")]
    [SerializeField] Image progressBarFill;
    
    [Space]
    [Header("Remaining Ads UI & Watch Ad Button")]
    [SerializeField] GameObject remainingAdsBadge;
    

    [Space]
    [Header("Rewards FX")]
    [SerializeField] ParticleSystem starsRewardFx;
    [SerializeField] ParticleSystem crownsRewardFx;

    [Space]
    [SerializeField] Button watchAdButton;
    TMP_Text watchAdButtonText;
    string watchAdButtonDefaultText;

    [Space]
    [Header("Admob reference")]
    [SerializeField] RewardAdMob admob;

    [Space]
    [SerializeField] TMP_Text watchedAdsText;

    [Space]
    [Header("Rewards Informations")]
    const int TOTAL_REWARDS=6;
    public UserReward[] userRewards=new UserReward[TOTAL_REWARDS];

    [Space]
    [Header("Animation Fx")]
    public Animator RewardNumberAnimation;

    static UserReward currentReward;
    static int currentRewardIndex;

    public bool isAdWatched;

    [Space]
    [Header("Time to wait (Minutes) before activating Rewards again")]
    public double waitTimeToActivateRewards;

    private void Awake()
    {
        

        watchAdButtonText=watchAdButton.transform.GetChild(0).GetComponent<TMP_Text>();
        watchAdButtonDefaultText = watchAdButtonText.text;

    }
    void Start()
    {
        RewardNumberAnimation.Play("RewardNumberAnimation");

        CheckForAvailableRewards();

        DrawRewardsUI();

        GameSharedUI.Instance.UpdateCoinsUIText();
        GameSharedUI.Instance.UpdateCrownsUIText();

   
        UpdateWatchedADsTextUI();
    }
  
    void DrawRewardsUI()
    {
        for (int i = currentRewardIndex; i < TOTAL_REWARDS; i++)
        {
            UserReward reward = userRewards[i];

            // Update UI elements
            // Reward Icon UI
            rewardsParent.GetChild(i).GetChild(1).GetComponent<Image>().sprite = reward.Icon;
            // Reward Amount UI
            rewardsParent.GetChild(i).GetChild(2).GetComponent<TMP_Text>().text = "+"+reward.Amount.ToString();

        }
    }
    public void WatchAdButtonClick()
    {
        isAdWatched = false;
        watchAdButton.interactable = false;
        watchAdButtonText.text = "LOADING..";


        //Request & Show Ad


		admob.RequestRewardAd();

    }


    public void AdClose()
    {
        watchAdButtonText.text = watchAdButtonDefaultText;

        if (isAdWatched)
        {
            //User watched the full AD
            watchAdButton.interactable = false;
            currentReward = userRewards[currentRewardIndex];
            currentRewardIndex++;
            float progressValue = (float)currentRewardIndex / TOTAL_REWARDS;

            progressBarFill.DOFillAmount(progressValue, 1.5f).OnComplete(RewardUser);

        }
        else
        {
            //User didn't complete the AD
            watchAdButton.interactable = true;
        }
    }
    void RewardUser()
    {
        watchAdButton.interactable = true;

        if (currentReward.RewardType == UserRewardType.Stars)
        {
            Debug.Log("<color=orange>Coins Reward : +" + currentReward.Amount + "</color>");

            GameDataManager.AddAlotOfCoins(currentReward.Amount);
            GameSharedUI.Instance.UpdateCoinsUIText();

            starsRewardFx.Play();
            SoundMangerScript.PlaySound("Reward");


        }
        else if (currentReward.RewardType == UserRewardType.Crowns)
        {
            Debug.Log("<color=green>Crowns Reward : +" + currentReward.Amount + "</color>");

            GameDataManager.AddAlotOfCrowns(currentReward.Amount);
            GameSharedUI.Instance.UpdateCrownsUIText();

            crownsRewardFx.Play();
            SoundMangerScript.PlaySound("Reward");
        }

       
        UpdateWatchedADsTextUI();

        MarkRewardAsCheked(currentRewardIndex - 1);

        //Save Progress
        PlayerPrefs.SetInt("CurrentRewardIndex", currentRewardIndex);

        //Check if it's last Reward
        if (currentRewardIndex == TOTAL_REWARDS)
        {
            //Save current system DateTime
            PlayerPrefs.SetString("RewardsCompletionDateTime", DateTime.Now.ToString());
        }

    }
    void MarkRewardAsCheked(int rewardIndex)
    {
        // hide the reward & show it's corresponding check mark.
        rewardsParent.GetChild(rewardIndex).gameObject.SetActive(false);
        rewardsCheckMarksParent.GetChild(rewardIndex).gameObject.SetActive(true);

        //Update Progress Bar
        float progressValue = (float)currentRewardIndex / TOTAL_REWARDS;
        progressBarFill.fillAmount = progressValue;

        //If it's the last Reward
        if (rewardIndex == TOTAL_REWARDS - 1)
        {
            watchAdButton.interactable = false;
            remainingAdsBadge.SetActive(false);
           

            currentRewardIndex = TOTAL_REWARDS;
        }
    }


    void CheckForAvailableRewards()
    {
        currentRewardIndex = PlayerPrefs.GetInt("CurrentRewardIndex", 0);

        //Check if it's the last Reward
        if (currentRewardIndex == TOTAL_REWARDS)
        {
            //Get saved date time
            DateTime rewardsCompletionDateTime = DateTime.Parse(PlayerPrefs.GetString("RewardsCompletionDateTime", DateTime.Now.ToString()));
            DateTime currentDateTime = DateTime.Now;

            //Get total minutes between this 2 dates
            double elapsedMinutes = (currentDateTime - rewardsCompletionDateTime).TotalMinutes; // BUNU .TotalHours YAP OYUN YAYINLARKEN

            Debug.Log("Time Passed Since Last Reward: " + elapsedMinutes);

            if (elapsedMinutes >= waitTimeToActivateRewards)
            {
                // Activate Rewards again
                PlayerPrefs.SetString("RewardsCompletionDateTime", "");
                PlayerPrefs.SetInt("CurrentRewardIndex", 0);
                currentRewardIndex = 0;

            }
            else
            {
                // show message to the user to wait more.
                Debug.Log("wait for " + (waitTimeToActivateRewards - elapsedMinutes) + " Minutes");
            }
        }

        //Check if already watched some ads
        if (currentRewardIndex > 0)
        {
            for (int i = 0; i < currentRewardIndex; i++)
            {
                MarkRewardAsCheked(i);
            }
        }
    }


    // Watched Ads & Remaining Rewards Text UI Update
    
    void UpdateWatchedADsTextUI()
    {
        watchedAdsText.text = string.Format("{0}/{1}", currentRewardIndex, TOTAL_REWARDS);
    }

}
