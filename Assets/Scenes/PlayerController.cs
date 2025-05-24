using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void OnPass()
    {
        GameManager.Instance.playerPassed = true;
        Debug.Log("Hr·Ë vynechal kolo!");
        GameManager.Instance.currentTurn = TurnState.AI;
        GameManager.Instance.CheckForEndOfRound();
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
