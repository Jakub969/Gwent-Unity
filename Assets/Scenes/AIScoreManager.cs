using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AIScoreManager : MonoBehaviour
{
    public Transform enemyMeleeRow;
    public Transform enemyRangedRow;
    public Transform enemySiegeRow;

    public TMP_Text meleeScoreText;
    public TMP_Text rangedScoreText;
    public TMP_Text siegeScoreText;
    public TMP_Text totalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        int melee = CalculateRow(enemyMeleeRow);
        int ranged = CalculateRow(enemyRangedRow);
        int siege = CalculateRow(enemySiegeRow);

        meleeScoreText.text = melee.ToString();
        rangedScoreText.text = ranged.ToString();
        siegeScoreText.text = siege.ToString();

        totalScoreText.text = (melee + ranged + siege).ToString();
    }

    int CalculateRow(Transform row)
    {
        int sum = 0;
        foreach (Transform card in row)
        {
            CardDisplay display = card.GetComponent<CardDisplay>();
            if (display != null)
                sum += display.GetCurrentStrengthWithBond(row);
        }
        return sum;
    }
}
