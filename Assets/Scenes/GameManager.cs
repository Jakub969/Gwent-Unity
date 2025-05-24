using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<CardData> playerHand = new List<CardData>();
    public List<CardData> playerDeck = new List<CardData>();
    public DeckManager deckManager; // pripojíš cez Inspector
    public LeaderData selectedLeader;
    public List<CardData> selectedCards = new List<CardData>();

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
