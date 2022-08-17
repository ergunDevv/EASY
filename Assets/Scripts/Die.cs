using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public ParticleSystem DestructionEffect;
    public bool isPlayerDead=false;

    public AdShower adShower;


    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Kill")
        {
            if (isPlayerDead == false)
            {
               
                SoundMangerScript.PlaySound("lavadie");

                ParticleSystem explosionEffect = Instantiate(DestructionEffect)
                                  as ParticleSystem;
                explosionEffect.transform.position = transform.position;
                //play it
                explosionEffect.loop = false;
                explosionEffect.Play();
                Destroy(explosionEffect.gameObject, explosionEffect.duration);
                //destroy the particle system when its duration is up, right

                SoundMangerScript.PlaySound("Die");
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                isPlayerDead = true;
            }
            
        }

    }
}
