using UnityEngine;
using UnityEngine.UI;

public class TooltipText : MonoBehaviour
{
    [SerializeField] private Text _text = null;


    public void ShowTooltip(string text)
    {
        _text.text = text;
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
