using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using TMPro;

//New Admob Reward API

public class ShopRewardButton : MonoBehaviour
{

	public string rewardAdShopID = "";


	RewardedAd rewardAdShop;

	public Button _shopRewardedAdButton;

	private bool isAdWatchedShop;

	

	[Space]
	[Header("Rewards FX")]
	[SerializeField] ParticleSystem starsRewardFx;

	void Start()
	{
		MobileAds.Initialize(initStatus => { });
	}
	public void WatchAdButtonClick()
	{
		isAdWatchedShop = false;
		_shopRewardedAdButton.interactable = false;
		


		//Request & Show Ad


		RequestRewardAd();

	}
	//Request Reward Ad
	public void RequestRewardAd()
	{
		//Remove existing events first to avoid executing an event twice.
		if (rewardAdShop != null)
        {
			RemoveRewardAdEvents();
		}
			

		rewardAdShop = new RewardedAd(rewardAdShopID);

		//Attach rewardAdShop events 
		AddRewardAdEvents();

		rewardAdShop.LoadAd(GetNewAdRequest());
	}

	//Reward events
	void RewardAd_OnUserEarnedReward(object sender, Reward e)
	{
		isAdWatchedShop = true;
		AdClose();
	}

	void RewardAd_OnAdClosed(object sender, EventArgs e)
	{

		
	}

	void RewardAd_OnAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
	{
		AdClose();
	}

	void RewardAd_OnAdLoaded(object sender, EventArgs e)
	{
		//Show the Ad
		rewardAdShop.Show();
	}

	// General Methods
	AdRequest GetNewAdRequest()
	{
		return new AdRequest.Builder().Build();
	}

	void AddRewardAdEvents()
	{
		//Add rewardAD events
		rewardAdShop.OnAdLoaded += RewardAd_OnAdLoaded;
		rewardAdShop.OnAdFailedToLoad += RewardAd_OnAdFailedToLoad;
		rewardAdShop.OnAdClosed += RewardAd_OnAdClosed;
		rewardAdShop.OnUserEarnedReward += RewardAd_OnUserEarnedReward;
	}

	void RemoveRewardAdEvents()
	{
		//Remove rewardAD events
		rewardAdShop.OnAdLoaded -= RewardAd_OnAdLoaded;
		rewardAdShop.OnAdFailedToLoad -= RewardAd_OnAdFailedToLoad;
		rewardAdShop.OnAdClosed -= RewardAd_OnAdClosed;
		rewardAdShop.OnUserEarnedReward -= RewardAd_OnUserEarnedReward;
	}
	public void AdClose()
	{


		if (isAdWatchedShop)
		{

			RewardUser();
		}
		else
		{
			_shopRewardedAdButton.interactable = true;
		}
	}
	void RewardUser()
	{
		_shopRewardedAdButton.interactable = true;

	
			Debug.Log("<color=orange>Coins Reward : +" + 10 + "</color>");

			GameDataManager.AddAlotOfCoins(10);
			GameSharedUI.Instance.UpdateCoinsUIText();

			starsRewardFx.Play();
			SoundMangerScript.PlaySound("Reward");

	}
	void OnDestroy()
	{
		RemoveRewardAdEvents();
	}
}

