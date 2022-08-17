using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class CharacterItemUI : MonoBehaviour
{

    [SerializeField] Color itemNotSelectedColor;
    [SerializeField] Color itemSelectedColor;


    [Space(20f)]

    [SerializeField] Image characterImage;
    [SerializeField] TMP_Text characterNameText;
    [SerializeField] TMP_Text characterFunInfoText;
    [SerializeField] TMP_Text characterPriceText;
    [SerializeField] TMP_Text characterPriceCrownText;
    [SerializeField] Button characterPurchaseButton;


    [Space(20f)]

    public Image starImage;
    public Image crownImage;
   


    [Space(20f)]

    [SerializeField] Button itemButton;
    [SerializeField] Image itemImage;
    [SerializeField] Outline itemOutline;

    [SerializeField] Animator anim;

    


    public void SetItemPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetCharacterImage(Sprite sprite)
    {
        characterImage.sprite = sprite;
    }
    public void SetCharacterName(string name)
    {
        characterNameText.text = name;
    }
    public void SetCharacterFunInfo(string funinfo)
    {
        characterFunInfoText.text = funinfo;
    }
    public void SetCharacterPrice(int price)
    {
        characterPriceText.text = price.ToString();

        if (price > 0)
        {
            characterPriceCrownText.enabled = false;
            crownImage.enabled = false;
        }
    }
 
    public void SetCharacterPriceCrown(int price)
    {
        characterPriceCrownText.text = price.ToString();
        
        if (price > 0)
        {
            characterPriceText.enabled = false;
            starImage.enabled = false;
        }
    }


    public void SetCharacterAsPurchased()
    {
        characterPurchaseButton.gameObject.SetActive(false);
        itemButton.interactable = true;

        itemImage.color = itemNotSelectedColor;

    }

    public void OnItemPurchase(int itemIndex, UnityAction<int> action)
    {
        characterPurchaseButton.onClick.RemoveAllListeners();
        characterPurchaseButton.onClick.AddListener(() => action.Invoke(itemIndex));

    }
    public void OnItemSelect(int itemIndex, UnityAction<int> action)
    {
        itemButton.interactable = true;
        itemButton.onClick.RemoveAllListeners();
        itemButton.onClick.AddListener(() => action.Invoke(itemIndex));


    }

    public void SelectItem()
    {
        itemOutline.enabled = true;
        itemImage.color = itemSelectedColor;
        itemButton.interactable = false;
        anim.enabled = true;


    }
    public void DeselectItem()
    {
        itemOutline.enabled = false;
        itemImage.color = itemNotSelectedColor;
        itemButton.interactable = true;
        anim.enabled = false;
    }
    


}
