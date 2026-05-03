using UnityEngine;

public class DeckBuilderController : MonoBehaviour
{
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private HandManager handManager;

    [SerializeField] private CardView cardPrefab;
    [SerializeField] private Transform deckPoint;


    public void OnDeckClicked()
    {
        if (handManager.IsFull) return;

        CardData data = deckManager.DrawCard();

        // Spawn card
        CardView card = Instantiate(cardPrefab, handManager.HandArea);

        card.Setup(data);

        // Immediately add to hand
        handManager.AddCard(card);
    }
}