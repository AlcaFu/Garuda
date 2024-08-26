using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SimpleButtonHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI text;
    private Image image;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Image imageTest = GetComponent<Image>();
        if (imageTest != null)
        {
            image = GetComponent<Image>();
            image.color = new Color32(255, 125, 5, 255);
        }
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        text.color = new Color32(255, 125, 5, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Image imageTest = GetComponent<Image>();
        if (imageTest != null)
        {
            image = GetComponent<Image>();
            image.color = new Color32(255, 255, 255, 255);
        }
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        text.color = new Color32(255, 255, 255, 255);
    }
}
