using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderCardUI : MonoBehaviour
{
    [Header("Common")]
    public LeaderData leaderData;
    public Image artworkImage;
    public Text descriptionText;
    public bool isInGameScene = false;

    [Header("Choosing Scene Only")]
    public GameObject leaderSelectionPanel;
    public Transform leaderOptionsParent;
    public GameObject leaderOptionPrefab;
    public List<LeaderData> availableLeaders;

    public void Start()
    {
        if (leaderData != null && artworkImage != null)
        {
            artworkImage.sprite = leaderData.artwork;
            if (descriptionText != null)
                descriptionText.text = leaderData.description;
        }
    }

    public void OnClick()
    {
        if (isInGameScene)
        {
            // Aktivuj schopnosù lÌdra
            if (leaderData != null && leaderData.ability != null)
            {
                leaderData.ability.Activate();
            }
        }
        else
        {
            // Zobraziù panel v˝beru vodcu
            if (leaderSelectionPanel != null)
            {
                leaderSelectionPanel.SetActive(true);
                SpawnLeaderOptions();
            }
        }
    }

    public void SetLeader(LeaderData newLeader)
    {
        leaderData = newLeader;
        artworkImage.sprite = newLeader.artwork;
        if (descriptionText != null)
            descriptionText.text = newLeader.description;

        if (!isInGameScene)
            leaderSelectionPanel.SetActive(false);
    }

    private void SpawnLeaderOptions()
    {
        foreach (Transform child in leaderOptionsParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var leader in availableLeaders)
        {
            GameObject option = Instantiate(leaderOptionPrefab, leaderOptionsParent);
            LeaderOption optionScript = option.GetComponent<LeaderOption>();
            optionScript.leaderData = leader;
            optionScript.target = this;
            option.GetComponent<Image>().sprite = leader.artwork;
        }
    }
}
