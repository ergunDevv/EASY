using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelProgressUI : MonoBehaviour
{
    [Header("UI references :")]
    [SerializeField] private Image uiFillImage;


    [Header("Player & Endline references :")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform endLineTransform;
    [SerializeField] private GameObject player;
   
    
    private float maxDistance;

  

    private void Start()
    {
        maxDistance = GetDistance();

    }
    private float GetDistance()
    {

        return Vector2.Distance(playerTransform.position, endLineTransform.position);


    }


    private void UpdateProgressFill(float value)
    {
        uiFillImage.fillAmount = value;
    }


    private void Update()
    {
        if (player != null)
        {
            if (playerTransform.position.x <= maxDistance && playerTransform.position.x <= endLineTransform.position.x)
            {
                float distance = 1 - (GetDistance() / maxDistance);
                UpdateProgressFill(distance);
            }
        }
        
        
    }
    
}