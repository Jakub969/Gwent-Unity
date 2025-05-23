using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Image cardImage;
    public CardData cardData;

    private Transform targetParent;

    public void Init(CardData data, Transform target)
    {
        cardData = data;
        targetParent = target;
        cardImage.sprite = cardData.artwork;
        var display = GetComponent<CardDisplay>();
        if (display != null)
        {
            display.cardData = data;
        }
    }

    public void OnClick()
    {
        
        transform.SetParent(targetParent, false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
