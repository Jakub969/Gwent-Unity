using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerRowScore : MonoBehaviour
{
    public TMP_Text scoreText;

    void Update()
    {
        int total = CalculateScore();

        scoreText.text = total.ToString();
    }
    public int GetCurrentScore()
    {
        return CalculateScore();
    }

    private int CalculateScore()
    {
        int total = 0;
        foreach (Transform card in transform)
        {
            CardDisplay display = card.GetComponent<CardDisplay>();
            if (display != null && display.cardData != null)
            {
                total += display.GetCurrentStrengthWithBond(transform);
            }
        }
        return total;
    }

}
