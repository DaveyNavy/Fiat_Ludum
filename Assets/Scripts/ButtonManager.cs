using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager : Button
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);

        transform.localScale = new Vector2(1.2f, 1.2f);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);

        transform.localScale = new Vector2(1f, 1f);
    }
}
