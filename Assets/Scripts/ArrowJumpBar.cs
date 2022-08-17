using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowJumpBar : MonoBehaviour
{
    
    [SerializeField] public Image uiPowerFillImage;

    [SerializeField] public PlayerEverything PlayerEverything;

    
    void Start()
    {
        

        PlayerEverything = PlayerEverything.GetComponent<PlayerEverything>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
            UpdateProgressFill(PlayerEverything.jumpTimer);
        


    }

    public void UpdateProgressFill(float value)
    {
        uiPowerFillImage.fillAmount = value;
    }
}
