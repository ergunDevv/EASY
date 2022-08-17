using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class VibrationSettings : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;


    Color backgroundDefaultColor, handleDefaultColor;

    Image backgroundImage, handleImage;

    Toggle toggle;

    Vector2 handlePosition;





    public TMP_Text vibrationOnText;
    public TMP_Text vibrationOffText;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();

        handlePosition = uiHandleRectTransform.anchoredPosition;

        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;




        if (PlayerPrefs.GetInt("vibrationtoggleplayerpref") == 0)
        {
            toggle.isOn = true;
            OnSwitch(true);
        }
        else
        {
            toggle.isOn = false;
            OnSwitch(false);
        }


        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
        {
            OnSwitch(true);
        }

    }

    void OnSwitch(bool on)
    {

        if (on)
        {
            uiHandleRectTransform.anchoredPosition = handlePosition * -1;
            PlayerPrefs.SetInt("vibrationtoggleplayerpref", 0);
            vibrationOnText.enabled = true;
            vibrationOffText.enabled = false;

        



        }
        else
        {
            uiHandleRectTransform.anchoredPosition = handlePosition;
            PlayerPrefs.SetInt("vibrationtoggleplayerpref", 1);
            vibrationOffText.enabled = true;
            vibrationOnText.enabled = false;

         


        }

        backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor;
        handleImage.color = on ? handleActiveColor : handleDefaultColor;




    }

    public void VibrationMute(bool on)
    {
        if (on)
        {


          
            PlayerPrefs.SetInt("vibrationtoggleplayerpref", 0);



        }
        else
        {


            
            PlayerPrefs.SetInt("vibrationtoggleplayerpref", 1);

        }


    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}
