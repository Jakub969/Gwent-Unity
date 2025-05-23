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
    public Transform enemyMeleeRow;
    public Transform enemyRangedRow;
    public Transform enemySiegeRow;


    void Start()
    {
        GameManager.Instance.deckManager = FindObjectOfType<DeckManager>();
        leaderImage.sprite = GameManager.Instance.selectedLeader.artwork;

        // Zmiešaj balíèek
        var allCards = new List<CardData>(GameManager.Instance.playerDeck);
        Shuffle(allCards);

        // Rozdelíme 10 do ruky, zvyšok do balíèka
        GameManager.Instance.playerHand.Clear();
        GameManager.Instance.playerDeck.Clear();

        int handCount = Mathf.Min(10, allCards.Count);

        for (int i = 0; i < handCount; i++)
            GameManager.Instance.playerHand.Add(allCards[i]);

        for (int i = handCount; i < allCards.Count; i++)
            GameManager.Instance.playerDeck.Add(allCards[i]);


        foreach (var data in GameManager.Instance.playerHand)
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
            logic.enemyMeleeRow = enemyMeleeRow;
            logic.enemyRangedRow = enemyRangedRow;
            logic.enemySiegeRow = enemySiegeRow;
            card.GetComponent<Button>().onClick.AddListener(logic.OnClick);
        }

    }
    void Shuffle(List<CardData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            var temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
