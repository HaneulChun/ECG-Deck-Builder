using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public string id;
    public string cardName;
    public int cost;
    public string stats;
    public Sprite illustration;
    public string description;
}
