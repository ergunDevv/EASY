using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdShower : MonoBehaviour
{

    public static AdShower instance;


    public string idApp = "";
    
    public static bool isBuyNoAds =false;

    int npaValue = -1;

    void Start()
    {
        npaValue = PlayerPrefs.GetInt("npa", 0);

        MobileAds.Initialize(initStatus => { });

       
    }


    AdRequest AdRequestBuild()
    {
        return new AdRequest.Builder().AddExtra("npa",npaValue.ToString()).Build();
    }

   

}
