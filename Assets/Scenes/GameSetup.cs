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
        leaderImage.sprite = GameManager.Instance.selectedLeader;

        foreach (var sprite in GameManager.Instance.selectedCards)
        {
            GameObject card = Instantiate(cardPrefab, playerHandParent);
            card.GetComponent<Image>().sprite = sprite;

            // Napríklad rozdelenie pod¾a názvu alebo indexu
            RowType type = RowType.Melee; // default

            if (sprite.name.ToLower().Contains("ranged")) type = RowType.Ranged;
            if (sprite.name.ToLower().Contains("siege")) type = RowType.Siege;

            var logic = card.AddComponent<CardInHand>();
            logic.cardSprite = sprite;
            logic.rowType = type;
            logic.meleeRow = meleeRow;
            logic.rangedRow = rangedRow;
            logic.siegeRow = siegeRow;
            card.GetComponent<Button>().onClick.AddListener(logic.PlayCard);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
