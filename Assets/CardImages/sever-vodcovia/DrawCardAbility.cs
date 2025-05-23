using UnityEngine;

[CreateAssetMenu(fileName = "DrawCardAbility", menuName = "Gwent/LeaderAbility/DrawCard")]
public class DrawCardAbility : LeaderAbilityBase
{
    public override void Activate()
    {
        Debug.Log("Aktivuj vodcu: Potiahni 1 kartu!");
        // sem príde logika pre potiahnutie
    }
}
