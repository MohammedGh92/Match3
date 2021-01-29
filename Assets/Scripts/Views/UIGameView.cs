using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// Game view with events for buttons and showing data.
/// </summary>
public class UIGameView : UIView
{
    // Reference to time label.

    public UnityAction OnFinishClicked,OnMenuClicked;

    /// <summary>
    /// Method called by Finish Button.
    /// </summary>
    public void FinishClick()
    {
        OnFinishClicked?.Invoke();
    }


    /// <summary>
    /// Method called by Menu Button.
    /// </summary>
    public void MenuClicked()
    {
        OnMenuClicked?.Invoke();
    }
 
}
