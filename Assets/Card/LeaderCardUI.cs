using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderCardUI : MonoBehaviour
{
    public GameObject leaderSelectionPanel;
    public Transform leaderOptionsParent; // napr. Grid
    public GameObject leaderOptionPrefab;
    public Image cardImage;
    public List<Sprite> availableLeaders;

    public void OnClick()
    {
        leaderSelectionPanel.SetActive(true);
        SpawnLeaderOptions();
    }

    public void SetLeader(Sprite newSprite)
    {
        cardImage.sprite = newSprite;
        leaderSelectionPanel.SetActive(false);
    }

    private void SpawnLeaderOptions()
    {
        foreach (Transform child in leaderOptionsParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var sprite in availableLeaders)
        {
            GameObject option = Instantiate(leaderOptionPrefab, leaderOptionsParent);
            var optionScript = option.GetComponent<LeaderOption>();
            optionScript.leaderSprite = sprite;
            optionScript.target = this;
            option.GetComponent<Image>().sprite = sprite;
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
