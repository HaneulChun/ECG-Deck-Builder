using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] private Transform handArea;
    [SerializeField] private float spacing = 150f;

    [SerializeField] private List<CardView> cards = new List<CardView>();

    public bool IsFull => cards.Count >= 8;
    public Transform HandArea => handArea;

    public void AddCard(CardView card)
    {
        cards.Add(card);
        UpdateLayout();
    }

    public Vector3 GetNextPosition()
    {
        int index = cards.Count;
        return handArea.position + new Vector3(index * spacing, 0, 0);
    }

    void UpdateLayout()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].SetHandPosition(
                handArea.position + new Vector3(i * spacing, 0, 0)
            );
        }
    }


    public List<string> GetCardIDs()
    {
        List<string> ids = new List<string>();

        foreach (var card in cards)
        {
            ids.Add(card.Data.id.ToString());
        }

        return ids;
    }

    public void Clear()
    {
        cards.Clear();
    }
}