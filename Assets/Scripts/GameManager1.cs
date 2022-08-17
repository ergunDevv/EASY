using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{

    public bool gameHasEnded;

    public GameObject completeLevelUI;
    public GameObject InGameMenu;
    public void CompleteLevel()
    {
        Time.timeScale = 0f;
        completeLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            InGameMenu.SetActive(true);
        }

    }


}
