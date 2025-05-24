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

    public void UpdateDisplayWithRow(Transform row)
    {
        int final = GetCurrentStrengthWithBond(row);

        if (strengthText != null)
            strengthText.text = final.ToString();
    }



    public int GetCurrentStrength()
    {
        return cardData.strength + bonus;
    }

    public int GetCurrentStrengthWithBond(Transform row)
    {
        if (cardData.ability != CardAbility.TightBond)
            return cardData.strength + bonus;

        int sameCardCount = 0;

        foreach (Transform card in row)
        {
            var display = card.GetComponent<CardDisplay>();
            if (display != null &&
                display.cardData.cardName == this.cardData.cardName &&
                display.cardData.ability == CardAbility.TightBond)
            {
                sameCardCount++;
            }
        }

        return (cardData.strength * sameCardCount) + bonus;
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
