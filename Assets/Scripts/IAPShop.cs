using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPShop : MonoBehaviour
{
    private string noads= "com.ergundev.jump.noads";
    private string crowns= "com.ergundev.jump.100crowns";
    public GameObject restorePurchaseBtn;
    public GameObject noAdsBtn;

    private void Awake()
    {
        DisableRestorePurchaseBtn();
        if (PlayerPrefs.GetInt("isBuyNoMoreAds")==1)
        {
            noAdsBtn.SetActive(false);
        }
    }
    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id== noads)
        {
            PlayerPrefs.SetInt("isBuyNoMoreAds", 1);
           // AdShower.instance.HideBannerAd();
            

        }
        if (product.definition.id == crowns)
        {
            GameDataManager.AddAlotOfCrowns(100);
            GameSharedUI.Instance.UpdateCrownsUIText();
        }
        
    }

    public void OnPurchaseFailed(Product product,PurchaseFailureReason reason)
    {
        print("Purchase of  " + product.definition.id + " failed due to " + reason);
    }

    private void DisableRestorePurchaseBtn()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            restorePurchaseBtn.SetActive(false);
        }
    }
}
