using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour
{
    public Image leaderImage;
    public Transform playerHandParent;
    public GameObject cardPrefab;
    public Transform meleeRow;
    public Transform rangedRow;
    public Transform siegeRow;


    void Start()
    {
        leaderImage.sprite = GameManager.Instance.selectedLeader.artwork;
        
        foreach (var data in GameManager.Instance.selectedCards)
        {
            GameObject card = Instantiate(cardPrefab, playerHandParent);
            CardDisplay display = card.GetComponent<CardDisplay>();
            display.cardData = data;
            display.Setup();

            CardInHand logic = card.AddComponent<CardInHand>();
            logic.cardData = data;
            logic.meleeRow = meleeRow;
            logic.rangedRow = rangedRow;
            logic.siegeRow = siegeRow;

            card.GetComponent<Button>().onClick.AddListener(logic.OnClick);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
