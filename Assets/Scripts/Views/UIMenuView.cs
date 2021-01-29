using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Menu view with events for buttons.
/// </summary>
public class UIMenuView : UIView
{
    // Event called when Play Button is clicked.
    public UnityAction OnStartClicked;

    /// <summary>
    /// Method called by Play Button.
    /// </summary>
    public void StartClicked()
    {
        OnStartClicked?.Invoke();
    }
 
}
