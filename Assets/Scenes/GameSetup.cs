using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour
{
    public Image leaderImage;
    public Transform playerHandParent;
    public GameObject cardPrefab;

    void Start()
    {
        leaderImage.sprite = GameManager.Instance.selectedLeader;

        foreach (var sprite in GameManager.Instance.selectedCards)
        {
            GameObject card = Instantiate(cardPrefab, playerHandParent);
            card.GetComponent<Image>().sprite = sprite;

            // MÙûeö sem daù skript na drag & drop neskÙr
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
