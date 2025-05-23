using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckConfirm : MonoBehaviour
{
    public LeaderCardUI leaderCardUI;           
    public Transform cardsInDeckParent;

    public void StartGame()
    {
        if (leaderCardUI == null)
        {
            Debug.LogError("LeaderCardUI nie je priradený!");
            return;
        }

        GameManager.Instance.selectedLeader = leaderCardUI.leaderData;

        GameManager.Instance.selectedCards.Clear();
        foreach (Transform card in cardsInDeckParent)
        {
            var display = card.GetComponent<CardDisplay>();
            if (display != null && display.cardData != null)
            {
                GameManager.Instance.playerDeck.Add(display.cardData);
            }
            else
            {
                Debug.LogWarning("Karta nemá CardDisplay alebo cardData!");
            }
        }


        SceneManager.LoadScene("GameScene");
    }
}
