using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public CardData cardData;

    public Image artworkImage;
    public TMP_Text strengthText;
    //public Text nameText;
    public int bonus = 0;

    public void Setup()
    {
        if (cardData == null)
        {
            Debug.LogWarning("cardData je null!");
            return;
        }

        artworkImage.sprite = cardData.artwork;
        strengthText.text = cardData.strength.ToString();
        //nameText.text = cardData.cardName;
    }

    public void UpdateDisplay() {
        strengthText.text = (cardData.strength + bonus).ToString();
    }

    public int GetCurrentStrength()
    {
        return cardData.strength + bonus;
    }

    void Start()
    {
        strengthText.text = cardData.strength.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
