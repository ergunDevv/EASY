using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMangerScript : MonoBehaviour
{
    public static AudioClip playerPickCoinSound,playerJumpSound,playerCrownSound,playerDieSound,playerRewardSound,playerLavadieSound,playerGravitySound;
    static AudioSource audioSrc;
    void Start()
    {

        playerPickCoinSound = Resources.Load<AudioClip>("CoinPick");
        playerJumpSound = Resources.Load<AudioClip>("Jump");
        playerCrownSound = Resources.Load<AudioClip>("CrownPick");
        playerDieSound = Resources.Load<AudioClip>("Die");
        playerRewardSound = Resources.Load<AudioClip>("Reward");
        playerLavadieSound = Resources.Load<AudioClip>("lavadie");
        playerGravitySound = Resources.Load<AudioClip>("GravitySound");
     

        audioSrc = GetComponent<AudioSource>();
        
    }



    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "coinPick":
                audioSrc.PlayOneShot(playerPickCoinSound);
                    break;
            case "Jump":
                audioSrc.PlayOneShot(playerJumpSound);
                    break;
            case "CrownPick":
                audioSrc.PlayOneShot(playerCrownSound);
                    break;
            case "Die":
                audioSrc.PlayOneShot(playerDieSound);
                    break;
            case "Reward":
                audioSrc.PlayOneShot(playerRewardSound);
                    break;
            case "lavadie":
                audioSrc.PlayOneShot(playerLavadieSound);
                    break;
            case "GravitySound":
                audioSrc.PlayOneShot(playerGravitySound);
                    break;
          
        }

    }

}
