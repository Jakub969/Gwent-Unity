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
        GameManager.Instance.selectedLeader = leaderCardUI.cardImage.sprite;

        GameManager.Instance.selectedCards.Clear();
        foreach (Transform card in cardsInDeckParent)
        {
            Sprite sprite = card.GetComponent<UnityEngine.UI.Image>().sprite;
            GameManager.Instance.selectedCards.Add(sprite);
        }

        SceneManager.LoadScene("GameScene");
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
