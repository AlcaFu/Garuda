using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsUIHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    private TextMeshProUGUI title;
    private GameObject arrowButton;
    [SerializeField] private Sprite unselect;
    [SerializeField] private Sprite select;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Transform buttonTransform = transform.Find("Button");
        if (buttonTransform != null && buttonTransform.gameObject != null)
        {
            arrowButton = buttonTransform.gameObject;
            arrowButton.SetActive(true);
        }
        title = transform.Find("Title").GetComponent<TextMeshProUGUI>();
        title.color = new Color32(255, 125, 5, 255);
        image = GetComponent<Image>();
        image.sprite = select;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Transform buttonTransform = transform.Find("Button");
        if (buttonTransform != null && buttonTransform.gameObject != null)
        {
            arrowButton = buttonTransform.gameObject;
            arrowButton.SetActive(true);
        }
        title = transform.Find("Title").GetComponent<TextMeshProUGUI>();
        title.color = new Color32(255, 255, 255, 255);
        image = GetComponent<Image>();
        image.sprite = unselect;
    }

    private void OnDisable()
    {
        Transform buttonTransform = transform.Find("Button");
        if (buttonTransform != null && buttonTransform.gameObject != null)
        {
            arrowButton = buttonTransform.gameObject;
            arrowButton.SetActive(true);
        }
        title = transform.Find("Title").GetComponent<TextMeshProUGUI>();
        image = GetComponent<Image>();
        if (title != null) title.color = new Color32(255, 255, 255, 255);
        if (image != null) image.sprite = unselect;
    }
}
