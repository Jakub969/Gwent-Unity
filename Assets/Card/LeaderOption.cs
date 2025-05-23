using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderOption : MonoBehaviour
{
    public LeaderData leaderData;
    public LeaderCardUI target;

    public void OnClick()
    {
        target.SetLeader(leaderData);
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
