using UnityEngine;

[CreateAssetMenu(fileName = "New Leader", menuName = "Gwent/Leader")]
public class LeaderData : ScriptableObject
{
    public string leaderName;
    public Sprite artwork;
    public string description;

    public LeaderAbilityBase ability; // abstraktný objekt, ktorý sa vykoná
}
