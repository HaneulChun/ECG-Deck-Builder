using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject front;
    [SerializeField] private GameObject back;
    public CardData Data { get; private set; }

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image illustration;

    private DeckBuilderController controller;

    private Vector3 handPosition;

    public void Init(CardData data, DeckBuilderController ctrl)
    {
        Data = data;

        nameText.text = data.cardName;
        cost.text = data.cost.ToString();
        descriptionText.text = data.description;
        illustration.sprite = data.illustration;

        controller = ctrl;

        // assign UI visuals here if needed
    }

    public void SetHandPosition(Vector3 pos)
    {
        handPosition = pos;
    }

    public Vector3 GetHandPosition()
    {
        return handPosition;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.OnCardClicked(this);
    }

    public IEnumerator PlayDrawSequence(Vector3 focusPos)
    {
        // start state
        front.SetActive(false);
        back.SetActive(true);

        yield return AnimateMove(transform.position + Vector3.up * 100f, 0.2f);
        yield return AnimateFlip();
        yield return AnimateMove(focusPos, 0.3f);
        yield return AnimateScale(1.5f, 0.3f);
    }

    public IEnumerator MoveToHand()
    {
        yield return AnimateScale(1f, 0.2f);
        yield return AnimateMove(handPosition, 0.3f);
    }


    IEnumerator AnimateMove(Vector3 target, float time)
    {
        Vector3 start = transform.position;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
    }

    IEnumerator AnimateScale(float target, float time)
    {
        Vector3 start = transform.localScale;
        Vector3 end = Vector3.one * target;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / time;
            transform.localScale = Vector3.Lerp(start, end, t);
            yield return null;
        }
    }

    IEnumerator AnimateFlip()
    {
        float t = 0;

        // shrink
        while (t < 1)
        {
            t += Time.deltaTime / 0.15f;
            transform.localScale = new Vector3(Mathf.Lerp(1, 0, t), 1, 1);
            yield return null;
        }

        // switch
        front.SetActive(true);
        back.SetActive(false);

        t = 0;

        // expand
        while (t < 1)
        {
            t += Time.deltaTime / 0.15f;
            transform.localScale = new Vector3(Mathf.Lerp(0, 1, t), 1, 1);
            yield return null;
        }
    }
}