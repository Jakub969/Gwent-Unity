using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerRowScore : MonoBehaviour
{
    public TMP_Text scoreText;

    void Update()
    {
        int total = 0;

        foreach (Transform card in transform)
        {
            CardDisplay display = card.GetComponent<CardDisplay>();
            if (display != null && display.cardData != null)
            {
                total += display.cardData.strength;
            }
        }

        scoreText.text = total.ToString();
    }
    public int GetCurrentScore()
    {
        int total = 0;
        foreach (Transform card in transform)
        {
            CardDisplay display = card.GetComponent<CardDisplay>();
            if (display != null && display.cardData != null)
            {
                total += display.cardData.strength;
            }
        }
        return total;
    }

}
