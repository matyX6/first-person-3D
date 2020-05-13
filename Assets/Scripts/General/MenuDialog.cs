using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuDialog : MonoBehaviour
{
    [SerializeField] private Text _titleDialog = null;
    [SerializeField] private Text _textButtonConfirm = null;
    [SerializeField] private Text _textButtonDecline = null;
    private Action _actionConfirm = null;


    public void ShowDialog(string title, string textButtonConfirm, string textButtonDecline, Action actionConfirm)
    {
        _titleDialog.text = title;
        _textButtonConfirm.text = textButtonConfirm;
        _textButtonDecline.text = textButtonDecline;
        _actionConfirm = actionConfirm;

        gameObject.SetActive(true);
    }

    public void ConfirmAction()
    {
        _actionConfirm.Invoke();
    }

    public void DeclineAction()
    {
    }
}
