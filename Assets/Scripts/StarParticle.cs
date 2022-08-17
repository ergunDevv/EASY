using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarParticle : MonoBehaviour
{
    public ParticleSystem DestructionEffect;
   


    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Instantiate our one-off particle system

            ParticleSystem explosionEffect = Instantiate(DestructionEffect)
                                        as ParticleSystem;
            explosionEffect.transform.position = transform.position;
            //play it
            explosionEffect.loop = false;
            explosionEffect.Play();
            Destroy(explosionEffect.gameObject, explosionEffect.duration);
            //destroy the particle system when its duration is up, right
            //it would play a second time.

            //destroy our game object

        }

    }
}


