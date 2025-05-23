using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform collectionParent;
    public Transform deckParent;
    public List<CardData> cardsData;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var data in cardsData)
        {
            GameObject card = Instantiate(cardPrefab, collectionParent);
            CardUI ui = card.GetComponent<CardUI>();
            ui.Init(data, deckParent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
