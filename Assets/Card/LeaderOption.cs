using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderOption : MonoBehaviour
{
    public Sprite leaderSprite;
    public LeaderCardUI target;

    public void OnClick()
    {
        target.SetLeader(leaderSprite);
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
