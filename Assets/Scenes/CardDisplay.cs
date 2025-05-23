using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public CardData cardData;

    public Image artworkImage;
    public Text strengthText;
    public Text nameText;

    public void Setup()
    {
        if (cardData == null)
        {
            Debug.LogWarning("cardData je null!");
            return;
        }

        if (artworkImage != null)
            artworkImage.sprite = cardData.artwork;

        if (strengthText != null)
            strengthText.text = cardData.strength.ToString();

        if (nameText != null)
            nameText.text = cardData.cardName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
