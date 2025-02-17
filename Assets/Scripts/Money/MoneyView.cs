using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    public event Action OnButtonClicked;
    
    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private Button _button;

    public void UpdateText(string newText)
    {
        _text.text = newText;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        OnButtonClicked?.Invoke();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }
}
