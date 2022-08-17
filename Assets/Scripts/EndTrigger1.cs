using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndTrigger1 : MonoBehaviour
{
    public GameManager1 gamemanger;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        gamemanger.CompleteLevel();
        
        MainMenu.SaveGame();
        PlayerPrefs.SetInt("LVL", SceneManager.GetActiveScene().buildIndex);
    }
}