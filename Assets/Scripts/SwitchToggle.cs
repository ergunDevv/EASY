using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;


    Color backgroundDefaultColor, handleDefaultColor;

    Image backgroundImage, handleImage;

    public Toggle toggle;

    Vector2 handlePosition;




    public TMP_Text soundsOnText;
    public TMP_Text soundsOffText;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();

        handlePosition = uiHandleRectTransform.anchoredPosition;

        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;
        



        if (PlayerPrefs.GetInt("toggleplayerpref") == 0)
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

    public void OnSwitch(bool on)
    {

        if (on)
        {
            uiHandleRectTransform.anchoredPosition = handlePosition * -1;
            PlayerPrefs.SetInt("toggleplayerpref", 0);
            soundsOnText.enabled = true;
            soundsOffText.enabled = false;
            AudioListener.pause = false;



        }
        else
        {
            uiHandleRectTransform.anchoredPosition = handlePosition;
            PlayerPrefs.SetInt("toggleplayerpref", 1);
            soundsOffText.enabled = true;
            soundsOnText.enabled = false;

   
            AudioListener.pause = true;

        }

        backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor;
        handleImage.color = on ? handleActiveColor : handleDefaultColor;




    }

    public void Mute(bool on)
    {
        if (on)
        {


            AudioListener.pause = false;



        }
        else
        {


            AudioListener.pause = true;

        }


    }

    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}
