using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controller responsible for game over phase.
/// </summary>
public class GameOverController : SubController<UIGameOverRoot>
{
    // Reference to current grid manager
    [SerializeField]
    private GridManager gridManager;
    public override void EngageController()
    {
        ui.GameOverView.OnRestartGame += RestartGame;
        base.EngageController();
        OnEngage();
    }

    public override void DisengageController()
    {
        base.DisengageController();
        // Detaching UI events.
        ui.GameOverView.OnRestartGame -= RestartGame;
    }


    private void OnEngage()
    {
    }

    /// <summary>
    /// Handling UI Replay Button Click.
    /// </summary>
    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
