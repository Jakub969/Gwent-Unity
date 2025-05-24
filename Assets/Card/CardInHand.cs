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
            Debug.Log("Karta je �pi�n � hr� sa na s�pera, hr�� potiahne 2 karty");
            Debug.Log(enemyMeleeRow);
            // Hra na s�pera � sem d� nesk�r enemy row
            transform.SetParent(enemyMeleeRow, false);
            //Debug.Log("Nov� rodi�: " + transform.parent.name);
            //Debug.Log("Lok�lna poz�cia: " + transform.localPosition);


            // Potiahni 2 karty z bal�ka hr��a
            GameManager.Instance.deckManager.DrawCard(2);


        }
        else if (cardData.ability == CardAbility.Spy && cardData.row == RowType.Siege)
        {
            transform.SetParent(enemySiegeRow, false); // do�asne daj sem enemyMeleeRow

            // Potiahni 2 karty z bal�ka hr��a
            GameManager.Instance.deckManager.DrawCard(2);


        }
        else
        {
            // Norm�lne zahratie
            Debug.Log("Karta " + cardData.cardName);
            Debug.Log("Posielam kartu do: " + cardData.row);
            transform.SetParent(targetRow, false);
            var display = GetComponent<CardDisplay>();
            display.UpdateDisplayWithRow(targetRow);

            if (cardData.ability == CardAbility.MoraleBoost)
            {
                foreach (Transform child in targetRow)
                {
                    if (child == this.transform) continue; // presko� seba

                    CardDisplay otherDisplay = child.GetComponent<CardDisplay>();
                    if (otherDisplay != null)
                    {
                        otherDisplay.bonus += 1;
                        otherDisplay.UpdateDisplayWithRow(targetRow);
                    }
                }
            }
            bool moraleBoostPresent = false;
            foreach (Transform child in targetRow)
            {
                if (child == this.transform) continue; // skip self

                CardDisplay otherDisplay = child.GetComponent<CardDisplay>();
                if (otherDisplay != null && otherDisplay.cardData.ability == CardAbility.MoraleBoost)
                {
                    moraleBoostPresent = true;
                    break;
                }
            }

            if (moraleBoostPresent && cardData.ability != CardAbility.MoraleBoost)
            {
                GetComponent<CardDisplay>().bonus += 1;
                Debug.Log("Morale Boost aplikovan� dodato�ne na kartu: " + cardData.cardName);
            }
            foreach (Transform card in targetRow)
            {
                var displayCard = card.GetComponent<CardDisplay>();
                if (displayCard != null)
                    displayCard.UpdateDisplayWithRow(targetRow);
            }

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
