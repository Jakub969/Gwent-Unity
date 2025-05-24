using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AIController : MonoBehaviour
{
    public Transform enemyMeleeRow;
    public Transform enemyRangedRow;
    public Transform enemySiegeRow;
    public Transform playerMeleeRow;
    public Transform playerRangedRow;
    public Transform playerSiegeRow;
    public GameObject cardPrefab;
    public TMP_Text passInfoText;

    void Start()
    {
        Debug.Log("AIController ötartuje...");
    }

    IEnumerator PlaySingleCardThenEndTurn()
    {
        yield return new WaitForSeconds(1f); // poËkaj na hr·Ëa

        
            Debug.Log("AI hand size: " + GameManager.Instance.enemyHand.Count);
            if (GameManager.Instance.aiPassed || GameManager.Instance.playerPassed)
                yield break;

        if (GameManager.Instance.enemyHand.Count <= 5 && GameManager.Instance.aiRoundsWon < 1)
        {
            GameManager.Instance.aiPassed = true;
            passInfoText.text = "AI vynechalo ùah!";
            Debug.Log("AI vynechalo kolo.");
            GameManager.Instance.currentTurn = TurnState.Player;
            GameManager.Instance.CheckForEndOfRound();
            yield break;
        }


        yield return new WaitForSeconds(1.5f);
            passInfoText.text = "AI hraje";
            // Zober najlepöiu kartu (s najv‰Ëöou silou)
            CardData best = null;
            int maxStrength = -1;

            foreach (var card in GameManager.Instance.enemyHand)
            {
                if (card.strength > maxStrength)
                {
                    best = card;
                    maxStrength = card.strength;
                }
            }

            if (best == null) yield break;

            GameManager.Instance.enemyHand.Remove(best);

            // Vytvor kartu
            GameObject cardGO = Instantiate(cardPrefab);
            Debug.Log("AI vytvoril kartu: " + best.cardName);

            var display = cardGO.GetComponent<CardDisplay>();
            display.cardData = best;
            display.Setup();

            // Zahraj do spr·vneho radu
            // Rozhodni cieæov˝ rad
            Transform targetRow = enemyMeleeRow;
            if (best.ability == CardAbility.Spy)
            {
                switch (best.row)
                {
                    case RowType.Melee: targetRow = playerMeleeRow; break;
                    case RowType.Ranged: targetRow = playerRangedRow; break;
                    case RowType.Siege: targetRow = playerSiegeRow; break;
                }
            }
            else
            {
                switch (best.row)
                {
                    case RowType.Ranged: targetRow = enemyRangedRow; break;
                    case RowType.Siege: targetRow = enemySiegeRow; break;
                }
            }


            cardGO.transform.SetParent(targetRow, false);
            Debug.Log("AI poslal " + best.cardName + " do radu: " + best.row);
            if (best.ability == CardAbility.Spy)
            {
                DrawCardsForAI(2);
            }
            if (best.ability == CardAbility.MoraleBoost)
            {
                foreach (Transform otherCard in targetRow)
                {
                    if (otherCard == cardGO.transform) continue;

                    var d = otherCard.GetComponent<CardDisplay>();
                    if (d != null)
                    {
                        d.bonus += 1;
                        d.UpdateDisplayWithRow(targetRow);
                    }
                }
            }
            // Ak treba, update bonus / strength
            // Update vöetk˝ch kariet v rade
            foreach (Transform otherCard in targetRow)
            {
                var d = otherCard.GetComponent<CardDisplay>();
                if (d != null)
                    d.UpdateDisplayWithRow(targetRow);
            }
        Debug.Log("AI konËÌ ùah, ùah hr·Ëa zaËÌna");

        GameManager.Instance.currentTurn = TurnState.Player;
        Debug.Log("Aktu·lny ùah: " + GameManager.Instance.currentTurn);

        //Debug.Log("AI deck size: " + GameManager.Instance.enemyDeck.Count);
        //Debug.Log("AI hand size: " + GameManager.Instance.enemyHand.Count);

    }

    public void PlayAITurn()
    {
        if (GameManager.Instance.aiPassed || GameManager.Instance.enemyHand.Count == 0)
        {
            GameManager.Instance.aiPassed = true;
            Debug.Log("AI pasuje (nem· karty).");
            GameManager.Instance.currentTurn = TurnState.Player;
            return;
        }

        StartCoroutine(PlaySingleCardThenEndTurn());
    }


    void DrawCardsForAI(int count)
    {
        for (int i = 0; i < count && GameManager.Instance.enemyDeck.Count > 0; i++)
        {
            CardData drawn = GameManager.Instance.enemyDeck[0];
            GameManager.Instance.enemyDeck.RemoveAt(0);
            GameManager.Instance.enemyHand.Add(drawn);

            Debug.Log("AI potiahlo kartu: " + drawn.cardName);
        }
    }

}
