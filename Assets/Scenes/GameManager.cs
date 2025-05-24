using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<CardData> playerHand = new List<CardData>();
    public List<CardData> playerDeck = new List<CardData>();
    public DeckManager deckManager; // pripoj� cez Inspector
    public LeaderData selectedLeader;
    public List<CardData> selectedCards = new List<CardData>();
    public List<CardData> enemyDeck = new List<CardData>();
    public List<CardData> enemyHand = new List<CardData>();
    public AIController aiController;
    public bool playerPassed = false;
    public bool aiPassed = false;
    public TurnState currentTurn = TurnState.Player;
    public int playerRoundsWon = 0;
    public int aiRoundsWon = 0;
    [HideInInspector] public Transform playerMeleeRow;
    [HideInInspector] public Transform playerRangedRow;
    [HideInInspector] public Transform playerSiegeRow;
    [HideInInspector] public Transform enemyMeleeRow;
    [HideInInspector] public Transform enemyRangedRow;
    [HideInInspector] public Transform enemySiegeRow;

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

    public void CheckForEndOfRound()
    {
        if (playerPassed && aiPassed)
        {
            PlayerTotalScore playerScoreComponent = FindObjectOfType<PlayerTotalScore>();
            int playerScore = playerScoreComponent != null ? playerScoreComponent.CalculatePlayerScore() : 0;
            AIScoreManager aIScore = FindObjectOfType<AIScoreManager>();
            int aiScore = aIScore != null ? aIScore.CalculateAIScore() : 0;

            if (playerScore > aiScore)
            {
                playerRoundsWon++;
                Debug.Log("Hr�� vyhral kolo!");
            }
            else if (aiScore > playerScore)
            {
                aiRoundsWon++;
                Debug.Log("AI vyhralo kolo!");
            }
            else
            {
                Debug.Log("Rem�za v kole.");
            }

            // Reset pre �al�ie kolo (alebo ukon�enie hry)
            StartCoroutine(NextRound());
        }
    }

    public IEnumerator NextRound()
    {
        if (playerRoundsWon >= 2)
        {
            Debug.Log("Hr�� vyhral hru!");
            // tu m��e� na��ta� v�hern� obrazovku alebo re�tart
            yield break;
        }
        else if (aiRoundsWon >= 2)
        {
            Debug.Log("AI vyhralo hru!");
            yield break;
        }
        Debug.Log("Za��name nov� kolo...");

        yield return new WaitForSeconds(2f); // chv�ka pauzy

        // 1. Vy�isti rady
        ClearRow(playerMeleeRow);
        ClearRow(playerRangedRow);
        ClearRow(playerSiegeRow);
        ClearRow(enemyMeleeRow);
        ClearRow(enemyRangedRow);
        ClearRow(enemySiegeRow);

        // 3. Vynuluj stav
        playerPassed = false;
        aiPassed = false;
        if (playerRoundsWon == 1 && aiRoundsWon == 0) 
        {
            currentTurn = TurnState.Player;
        }
        else if (playerRoundsWon == 0 && aiRoundsWon == 1)
        {
            currentTurn = TurnState.AI;
        }
        else
        {
            currentTurn = (currentTurn == TurnState.Player) ? TurnState.AI : TurnState.Player;
        }


        // 4. M��e� potiahnu� 1 kartu ako vo Witcher 3 (volite�n�)
        if (playerDeck.Count > 0)
        {
            var draw = playerDeck[0];
            playerDeck.RemoveAt(0);
            playerHand.Add(draw);
        }

        if (enemyDeck.Count > 0)
        {
            var draw = enemyDeck[0];
            enemyDeck.RemoveAt(0);
            enemyHand.Add(draw);
        }

        // 5. Re�tartuj hern� sc�nu (volite�ne), alebo ru�ne vytvor nov� karty
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void ClearRow(Transform row)
    {
        foreach (Transform child in row)
        {
            Destroy(child.gameObject);
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
