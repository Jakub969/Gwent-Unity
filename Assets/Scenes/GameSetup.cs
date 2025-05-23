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

        // Zmie�aj bal��ek
        var allCards = new List<CardData>(GameManager.Instance.playerDeck);
        Shuffle(allCards);

        // Rozdel�me 10 do ruky, zvy�ok do bal��ka
        GameManager.Instance.playerHand.Clear();
        GameManager.Instance.playerDeck.Clear();

        int handCount = Mathf.Min(10, allCards.Count);

        for (int i = 0; i < handCount; i++)
            GameManager.Instance.playerHand.Add(allCards[i]);

        for (int i = handCount; i < allCards.Count; i++)
        {
            GameManager.Instance.playerDeck.Add(allCards[i]);
        }

        // TEST: Napln�me enemyDeck pre AI
        GameManager.Instance.enemyHand.Clear();
        GameManager.Instance.enemyDeck.Clear();
        GameManager.Instance.enemyDeck.AddRange(GameManager.Instance.playerHand);
        // Potiahni 10 kariet pre AI
        for (int i = 0; i < 10 && GameManager.Instance.enemyDeck.Count > 0; i++)
        {
            var card = GameManager.Instance.enemyDeck[0];
            GameManager.Instance.enemyDeck.RemoveAt(0);
            GameManager.Instance.enemyHand.Add(card);
        }


        foreach (var data in GameManager.Instance.playerHand)
        {
            if (data.artwork == null)
            {
                Debug.LogWarning("Karta " + data.cardName + " nem� artwork!");
            }
            if (data.cardName == null || data.cardName.Trim() == "")
            {
                Debug.LogWarning("Karta m� pr�zdny n�zov!");
            }

            GameObject card = Instantiate(cardPrefab, playerHandParent);
            CardDisplay display = card.GetComponent<CardDisplay>();
            display.cardData = data;
            Debug.Log("Card name: " + data.cardName);
            Debug.Log("Card artwork: " + data.artwork);
            Debug.Log("Card description: " + data.strength);
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
