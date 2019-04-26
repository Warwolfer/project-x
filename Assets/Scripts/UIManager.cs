using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class UIManager : MonoBehaviour
{
    public Image[] healths;
    public GameObject[] pauseMenu;
    public GameObject[] overMenu;
    public GameObject[] mainMenu;
    public GameObject[] optionMenu;
    public GameObject[] finishMenu;
    public Text scoreText;
    CanvasGroup canvasGroup;

    // Use this for initialization
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFadeIn());
    }

    void Update()
    {
        // if (DataManager.instance.CheckGameState("PauseState"))
        // {
        //     showPaused();
        //     hideFinished();
        // }
        // else
        // {
        //     hidePaused();
        //     if (DataManager.instance.CheckGameState("GameOverState"))
        //     {
        //         hideFinished();
        //         showOver();
        //     }
        //     else
        //     {
        //         hideOver();
        //         if (DataManager.instance.CheckGameState("PlayingState"))
        //         {
        //             UpdateScore();
        //             hideFinished();
        //         }
        //         else
        //         {
        //             if (DataManager.instance.CheckGameState("FinishState"))
        //             {
        //                 showFinished();
        //             }
        //             else
        //             {
        //                 hideFinished();
        //             }
        //         }
        //     }
        // }
    }

    // Update is called once per frame
    public void UpdateHealth(int health)
    {
        // for (int i = 0; i < healths.Length; i++)
        // {
        //     if (i < health/10)
        //     {
        //         healths[i].gameObject.SetActive(true);
        //     }
        //     else
        //     {
        //         healths[i].gameObject.SetActive(false);
        //     }

        // }
    }

    public void LoadLevel(string level)
    {
        new LoadScene().Execute(level);
    }

    public void MainMenu()
    {
        new LoadMainMenu().Execute();
    }

    public void Restart()
    {
        new ReloadLevel().Execute();
    }

    // public void Resume()
    // {
    //     new PauseGame().Execute();
    // }

    public void Quit()
    {
        new ExitCommand().Execute();
    }

    public void ConfirmOption()
    {
        hideOption();
        ShowMain();
    }

    public void Option()
    {
        hideMain();
        showOption();
    }

    public void showPaused()
    {
        foreach (GameObject g in pauseMenu)
        {
            g.SetActive(true);
        }
    }

    public void hidePaused()
    {
        foreach (GameObject g in pauseMenu)
        {
            g.SetActive(false);
        }
    }

    public void showFinished()
    {
        foreach (GameObject g in finishMenu)
        {
            g.SetActive(true);
        }
    }

    public void hideFinished()
    {
        foreach (GameObject g in finishMenu)
        {
            g.SetActive(false);
        }
    }

    public void showOver()
    {
        foreach (GameObject g in overMenu)
        {
            g.SetActive(true);
        }
    }

    public void hideOver()
    {
        foreach (GameObject g in overMenu)
        {
            g.SetActive(false);
        }
    }

    public void ShowMain()
    {
        foreach (GameObject g in mainMenu)
        {
            g.SetActive(true);
        }
    }

    public void hideMain()
    {
        foreach (GameObject g in mainMenu)
        {
            g.SetActive(false);
        }
    }

    public void showOption()
    {
        foreach (GameObject g in optionMenu)
        {
            g.SetActive(true);
            g.GetComponentInChildren<Slider>().value = AudioListener.volume;
        }
    }

    public void hideOption()
    {
        foreach (GameObject g in optionMenu)
        {
            g.SetActive(false);
        }
    }

    public void changeVolume()
    {
        AudioListener.volume = GameObject.Find("VolumeSlider").GetComponent<Slider>().value;
    }

    public void startGame()
    {
        StartCoroutine(StartGameFade());
    }

    IEnumerator StartGameFade()
     {
         yield return DoFadeOut();
         StartCoroutine(LoadYourAsyncScene("SampleScene"));
     }

    IEnumerator DoFadeOut()
     {
         float elapsedTime = 0;
         float fadeTime = 2f;
         while(canvasGroup.alpha > 0)
         {
             elapsedTime += Time.deltaTime;
             canvasGroup.alpha = Mathf.Clamp01(1.0f - (elapsedTime / fadeTime));
             yield return null;
         }
     }

     IEnumerator DoFadeIn()
     {
         float elapsedTime = 0;
         float fadeTime = 2f;
         while(canvasGroup.alpha < 1)
         {
             elapsedTime += Time.deltaTime;
             canvasGroup.alpha = Mathf.Clamp01(0 + (elapsedTime / fadeTime));
             yield return null;
         }
     }

     IEnumerator LoadYourAsyncScene(string scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
