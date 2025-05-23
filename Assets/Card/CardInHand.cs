using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInHand : MonoBehaviour
{
    public CardData cardData;

    public Transform meleeRow;
    public Transform rangedRow;
    public Transform siegeRow;
    public Transform enemySiegeRow;
    public Transform enemyMeleeRow;
    public Transform enemyRangedRow;

    public void OnClick()
    {
        Transform targetRow = meleeRow; // default

        switch (cardData.row)
        {
            case RowType.Melee:
                targetRow = meleeRow;
                break;
            case RowType.Ranged:
                targetRow = rangedRow;
                break;
            case RowType.Siege:
                targetRow = siegeRow;
                break;
        }

        if (cardData.ability == CardAbility.Spy && cardData.row == RowType.Melee)
        {
            Debug.Log("Karta je špión – hrá sa na súpera, hráè potiahne 2 karty");
            Debug.Log(enemyMeleeRow);
            // Hra na súpera – sem dáš neskôr enemy row
            transform.SetParent(enemyMeleeRow, false);
            //Debug.Log("Nový rodiè: " + transform.parent.name);
            //Debug.Log("Lokálna pozícia: " + transform.localPosition);


            // Potiahni 2 karty z balíka hráèa
            GameManager.Instance.deckManager.DrawCard(2);


        }
        else if (cardData.ability == CardAbility.Spy && cardData.row == RowType.Siege)
        {
            transform.SetParent(enemySiegeRow, false); // doèasne daj sem enemyMeleeRow

            // Potiahni 2 karty z balíka hráèa
            GameManager.Instance.deckManager.DrawCard(2);


        }
        else
        {
            // Normálne zahratie
            Debug.Log("Karta " + cardData.cardName);
            Debug.Log("Posielam kartu do: " + cardData.row);
            transform.SetParent(targetRow, false);
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
