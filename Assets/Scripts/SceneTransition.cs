using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public GameObject SceneTransitionAnimation;
    public PlayerEverything player;
    public Die die;
    
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerEverything>();
        
        die.GetComponent<Die>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
       
        
            if (player.dieTimer <= 0 || die.isPlayerDead)
            {
                StartCoroutine(SceneTransitionAnimation1());
                StartCoroutine(SceneEndAnimation());

            }
        
       
    }

    [System.Obsolete]
    public IEnumerator SceneTransitionAnimation1()
    {
        
        yield return new WaitForSecondsRealtime(0.8f);      
        SceneTransitionAnimation.GetComponent<Animator>().Play("SceneAnimation");
  

    }
    public IEnumerator SceneEndAnimation()
    {
     
        yield return new WaitForSecondsRealtime(1.2f);      
        FindObjectOfType<GameManager1>().EndGame();
        player.isPlayerDead = true;
    }
}
