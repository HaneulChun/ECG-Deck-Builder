using System.Collections;
using UnityEngine;

public class DeckBuilderController : MonoBehaviour
{
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private HandManager handManager;
    [SerializeField] private CardView cardPrefab;

    [SerializeField] private Transform focusPoint;
    [SerializeField] private Transform DecPos;

    private enum State
    {
        Idle,
        Focusing
    }

    private State state = State.Idle;
    private CardView currentCard;

    // ---------------- DECK CLICK ----------------

    public void OnDeckClicked()
    {
        if (state != State.Idle || handManager.IsFull)
            return;

        CardData data = deckManager.DrawCard();

        CardView card = Instantiate(cardPrefab, handManager.HandArea);
        card.Init(data, this);

        card.transform.position = DecPos.position;

        card.SetHandPosition(handManager.GetNextPosition());

        currentCard = card;
        state = State.Focusing;

        StartCoroutine(DrawRoutine(card));
    }

    IEnumerator DrawRoutine(CardView card)
    {
        yield return card.PlayDrawSequence(focusPoint.position);
    }

    // ---------------- CARD CLICK ----------------

    public void OnCardClicked(CardView card)
    {
        if (state != State.Focusing || card != currentCard)
            return;

        StartCoroutine(FinishToHand(card));
    }

    IEnumerator FinishToHand(CardView card)
    {
        yield return card.MoveToHand();

        handManager.AddCard(card);

        currentCard = null;
        state = State.Idle;
    }
}