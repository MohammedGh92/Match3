using UnityEngine;

/// <summary>
/// Controller responsible for menu phase.
/// </summary>
public class MenuController : SubController<UIMenuRoot>
{
    public override void EngageController()
    {
        // Attaching UI events.
        ui.MenuView.OnStartClicked += StartClicked;

        base.EngageController();
    }


    public override void DisengageController()
    {
        base.DisengageController();

        // Detaching UI events.
        ui.MenuView.OnStartClicked -= StartClicked;
    }

    /// <summary>
    /// Handling UI Start Button Click.
    /// </summary>
    private void StartClicked()
    {
        Debug.Log("StartClicked");
        // Changing controller to Game Controller.
        root.ChangeController(RootController.ControllerTypeEnum.Game);
    }

}
