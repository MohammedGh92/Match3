using UnityEngine;

/// <summary>
/// Controller responsible for game phase.
/// </summary>
public class GameController : SubController<UIGameRoot>
{
    [SerializeField]
    private GridManager gridManager;
    public override void EngageController()
    {

        Debug.Log("EngageController");
        // ui.GameView.OnMenuClicked -= GoToMenu;
        base.EngageController();
        OnEngage();
    }

    private void OnEngage()
    {
        gridManager.GenerateNewGrid();
    }

    public override void DisengageController()
    {
        base.DisengageController();

        // Detaching UI events.
        // ui.GameView.OnMenuClicked -= GoToMenu;
    }

}
