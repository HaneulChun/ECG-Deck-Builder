using UnityEngine;
using UnityEngine.EventSystems;

public class DeckClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private DeckBuilderController controller;

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.OnDeckClicked();
    }
}