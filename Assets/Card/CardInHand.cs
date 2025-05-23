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

        // Presuò kartu do cie¾ového radu
        transform.SetParent(targetRow, false);
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
