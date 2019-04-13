using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Command  {
    public abstract void Execute();
    public abstract void Execute(CharController charController);
}

/* public class PauseGame : Command   {
    public override void Execute()   {
        if (DataManager.instance.CheckGameState("PauseState"))   {
            DataManager.instance.SetGameState(new PlayingState());
        }
        else  {
            DataManager.instance.SetGameState(new PauseState());
        }
    }

    public override void Execute(Robot robot)  {

    }
}*/

public class ReloadLevel : Command
{
    public override void Execute()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(scene);
    }

    public override void Execute(CharController charController)
    {

    }
}

public class LoadScene : Command
{
    public override void Execute()
    {

    }

    public override void Execute(CharController charController)
    {

    }

    public void Execute(string level)
    {
        SceneManager.LoadScene(level);
    }
}

public class ExitCommand : Command
{
    public override void Execute()
    {
        Application.Quit();
    }

    public override void Execute(CharController charController)
    {

    }
}

public class LoadMainMenu : Command
{
    public override void Execute()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public override void Execute(CharController charController)
    {

    }

}