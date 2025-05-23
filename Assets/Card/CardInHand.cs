using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInHand : MonoBehaviour
{
    public Sprite cardSprite;
    public RowType rowType;
    public Transform meleeRow;
    public Transform rangedRow;
    public Transform siegeRow;


    public void PlayCard()
    {
        Transform target = meleeRow; // default fallback

        switch (rowType)
        {
            case RowType.Melee:
                target = meleeRow;
                break;
            case RowType.Ranged:
                target = rangedRow;
                break;
            case RowType.Siege:
                target = siegeRow;
                break;
        }

        GameObject newCard = new GameObject("PlayedCard");
        newCard.transform.SetParent(target, false);

        var image = newCard.AddComponent<Image>();
        image.sprite = cardSprite;

        Destroy(gameObject);
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
