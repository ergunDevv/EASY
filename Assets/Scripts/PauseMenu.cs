using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject ShopPanel;

    public GameObject SettingsPanel;

    public GameObject adMobRewardPanel;


    

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;


       
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }
    public void OpenShop()
    {
        ShopPanel.SetActive(true);
    }
    public void CloseShop()
    {
        ShopPanel.SetActive(false);
    }
    public void OpenShopInGame()
    {
        Pause();
        ShopPanel.SetActive(true);
    }
    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
    }
    public void OpenAdMobReward()
    {
        adMobRewardPanel.SetActive(true);
        

        
        GameIsPaused = true;
    }
    public void CloseAdMobReward()
    {
        adMobRewardPanel.SetActive(false);
       


     
        GameIsPaused = false;
    }
    

    public void OnUserClickPrivacyPolicy()
    {
        Application.OpenURL("https://sites.google.com/view/ergundev/ana-sayfa");
    }
    public void OnUserClickTermsAndConditions()
    {
        Application.OpenURL("https://sites.google.com/view/ergundev-termsconditions/home");
    }
    public void OnUserClickTwitterButton()
    {
        Application.OpenURL("https://twitter.com/Ergun_Dev");
    }
    public void OnUserClickInstagramButton()
    {
        Application.OpenURL("https://www.instagram.com/erguncyln_/");
    }
}
