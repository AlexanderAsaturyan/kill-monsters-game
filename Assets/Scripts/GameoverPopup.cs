using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameoverPopup : MonoBehaviour
{
    public event Action OnBackToMenuButtonClicked;

    [SerializeField] private Button backToMenuButton;

    private void Start()
    {
        backToMenuButton.onClick.AddListener(InvokeClickEvent);
    }

    private void InvokeClickEvent()
    {
        OnBackToMenuButtonClicked?.Invoke();
    }

}
