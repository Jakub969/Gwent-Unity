using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform enemyMeleeRow;
    public Transform enemyRangedRow;
    public Transform enemySiegeRow;
    public Transform playerMeleeRow;
    public Transform playerRangedRow;
    public Transform playerSiegeRow;
    public GameObject cardPrefab;

    void Start()
    {
        Debug.Log("AIController štartuje...");
        StartCoroutine(PlayCardsRoutine());
        
    }

    IEnumerator PlayCardsRoutine()
    {
        yield return new WaitForSeconds(2f); // poèkaj na hráèa

        while (GameManager.Instance.enemyHand.Count > 0)
        {
            Debug.Log("AI hand size: " + GameManager.Instance.enemyHand.Count);

            yield return new WaitForSeconds(1.5f);

            // Zober najlepšiu kartu (s najväèšou silou)
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

            // Zahraj do správneho radu
            Transform targetRow = enemyMeleeRow;
            switch (best.row)
            {
                case RowType.Ranged: targetRow = enemyRangedRow; break;
                case RowType.Siege: targetRow = enemySiegeRow; break;
            }
            if (best.ability == CardAbility.Spy && best.row == RowType.Siege) {
                targetRow = playerSiegeRow; // Spy cards go to enemy siege row
            }
            else if (best.ability == CardAbility.Spy && best.row == RowType.Melee)
            {
                targetRow = playerMeleeRow; // Spy cards go to enemy ranged row
            }

            cardGO.transform.SetParent(targetRow, false);
            Debug.Log("AI poslal " + best.cardName + " do radu: " + best.row);

            // Ak treba, update bonus / strength
            display.UpdateDisplayWithRow(targetRow);
        }
        Debug.Log("AI hand size: " + GameManager.Instance.enemyHand.Count);

    }
}
