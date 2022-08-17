using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
   
    public GameObject TutorialMenuUI;
    
    void Start()
    {

        if (PlayerPrefs.GetFloat("tutorial") == 0)
        {
            Pause();
        }

    }
    public void Play()
    {
        TutorialMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PlayerPrefs.SetFloat("tutorial", 1);

    }
    public void Pause()
    {
        TutorialMenuUI.SetActive(true);
        Time.timeScale = 0f;
        

    }

}
