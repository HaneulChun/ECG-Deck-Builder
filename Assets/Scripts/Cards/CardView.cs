using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private GameObject front;
    [SerializeField] private GameObject back;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image illustration;

    private CardData data;
    public CardData Data => data;

    public void Setup(CardData cardData)
    {
        data = cardData;
        nameText.text = data.cardName;
        cost.text = data.cost.ToString();
        descriptionText.text = data.description;
        illustration.sprite = data.illustration;
    }


    public void ShowFront (bool showFront)
    {
        front.SetActive(showFront);
        back.SetActive(!showFront);
    }
}
