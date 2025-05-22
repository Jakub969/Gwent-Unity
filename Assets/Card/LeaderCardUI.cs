using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderCardUI : MonoBehaviour
{
    public GameObject leaderSelectionPanel; // panel so všetkými lídrami
    public Image cardImage;

    public void OnClick()
    {
        leaderSelectionPanel.SetActive(true);
    }

    public void SetLeader(Sprite newLeaderSprite)
    {
        cardImage.sprite = newLeaderSprite;
        leaderSelectionPanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        leaderSelectionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
