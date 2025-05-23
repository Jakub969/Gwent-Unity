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

    void Start()
    {
        artworkImage.sprite = cardData.artwork;
        strengthText.text = cardData.strength.ToString();
        nameText.text = cardData.cardName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
