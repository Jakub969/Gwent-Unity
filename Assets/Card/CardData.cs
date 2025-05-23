using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Gwent/Card")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite artwork;
    public int strength;
    public RowType row;
    public CardAbility ability;
}
