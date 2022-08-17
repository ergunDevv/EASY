using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveLoadGame : MonoBehaviour
{


public int My_LVL;



void Start()
{
    My_LVL = PlayerPrefs.GetInt("LVL", 0);
    if (My_LVL < SceneManager.GetActiveScene().buildIndex)
    {
        PlayerPrefs.SetInt("LVL", SceneManager.GetActiveScene().buildIndex);

    }
    My_LVL = PlayerPrefs.GetInt("LVL");
    if (My_LVL != SceneManager.GetActiveScene().buildIndex)
    {
        SceneManager.LoadScene(My_LVL);
    }
}

} 
