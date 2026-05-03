using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] private List<CardView> cards = new List<CardView>();

    [SerializeField] private int maxCards = 8;

    [Header("Layout")]
    [SerializeField] private Transform handArea;
    [SerializeField] private float spacing = 200f;

    public bool IsFull => cards.Count >= maxCards;
    public Transform HandArea => handArea;

    public void AddCard(CardView card)
    {
        if (IsFull) return;

        cards.Add(card);
        UpdateLayout();
    }

    void UpdateLayout()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.position = GetPosition(i);
        }
    }

    Vector3 GetPosition(int index)
    {
        float startX = -(cards.Count - 1) * spacing / 2f;
        return handArea.position + new Vector3(startX + index * spacing, 0, 0);
    }

    public List<string> GetCardIDs()
    {
        return cards.Select(c => c.Data.id).ToList();
    }
}