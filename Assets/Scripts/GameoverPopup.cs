using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class GameoverPopup : MonoBehaviour
{
    public event Action OnBackToMenuButtonClicked;

    [SerializeField] private Button backToMenuButton;
    [SerializeField] private TextMeshProUGUI popupScoreText;

    public TextMeshProUGUI PopupScoreText => popupScoreText;

    public string STRING => popupScoreText.text;

    private void Start()
    {
        backToMenuButton.onClick.AddListener(InvokeClickEvent);
    }

    private void InvokeClickEvent()
    {
        OnBackToMenuButtonClicked?.Invoke();
    }

}
