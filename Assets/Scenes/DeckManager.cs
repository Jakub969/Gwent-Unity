using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public Transform enemyMeleeRow;
    public Transform enemySiegeRow;

    public Transform playerHandParent;
    public GameObject cardPrefab;
    public Transform meleeRow, rangedRow, siegeRow;

    public void DrawCard(int count)
    {
        for (int i = 0; i < count && GameManager.Instance.playerDeck.Count > 0; i++)
        {
            CardData cardData = GameManager.Instance.playerDeck[0];
            GameManager.Instance.playerDeck.RemoveAt(0);

            GameObject card = Instantiate(cardPrefab, playerHandParent);
            var display = card.GetComponent<CardDisplay>();
            display.cardData = cardData;
            display.Setup();
            Debug.Log("Pridávam kartu do ruky: " + cardData.cardName);


            var logic = card.GetComponent<CardInHand>();
            if (logic == null)
                logic = card.AddComponent<CardInHand>();
            logic.cardData = cardData;
            logic.meleeRow = meleeRow;
            Debug.Log("Nastavené rady pre kartu: melee=" + logic.meleeRow);
            logic.rangedRow = rangedRow;
            logic.siegeRow = siegeRow;
            logic.enemyMeleeRow = enemyMeleeRow;
            Debug.Log("Nastavené rady pre moje: enemyMelee=" + enemyMeleeRow);
            Debug.Log("Nastavené rady pre nepriatela: enemyMelee=" + logic.enemyMeleeRow);
            logic.enemySiegeRow = enemySiegeRow;
            card.GetComponent<Button>().onClick.AddListener(logic.OnClick);
        }
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
