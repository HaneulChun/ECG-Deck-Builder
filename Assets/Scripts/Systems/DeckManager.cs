using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private List<CardData> allCards;
    private Stack<CardData> deck;

    void Start()
    {
        // InitializeDeck
        var shuffled = allCards.OrderBy(x => Random.value).ToList();
        deck = new Stack<CardData>(shuffled);
    }


    public CardData DrawCard()
    {
        return deck.Pop();
    }
}