using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using TMPro;

/// <summary>
/// Game over view with events for buttons and showing data.
/// </summary>
public class UIGameOverView : UIView
{

    public UnityAction OnRestartGame;
    public TextMeshProUGUI ResultTxt;

    /// <summary>
    /// Method called by Replay Button.
    /// </summary>
    public void RestartGame()
    {
        OnRestartGame?.Invoke();
    }


}
