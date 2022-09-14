using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    // Start is called before the first frame update
    public GameObject settingCanvas;
    
    private void Awake()
    {
        instance = this;
    }

    public void play()
    {
        AudioManager._instance.Play("ClickSound");
        SceneManager.LoadScene(1);
    }

    public void exit()
    {
        AudioManager._instance.Play("ClickSound");
        Application.Quit();
    }

    public void Menu()
    {
        AudioManager._instance.Play("ClickSound");
        SceneManager.LoadScene("MenuScene");
        
    }
    public void pause()
    {
        AudioManager._instance.Play("ClickSound");
        Time.timeScale = 0f;
        GameManager._instance.SetGameState(GameState.PAUSE);
        
    }
    public void Resume()
    {
        AudioManager._instance.Play("ClickSound");
        Time.timeScale = 1f;
        GameManager._instance.SetGameState(GameState.GAME_ON);
        
    }
    public void Restart()
    {
        AudioManager._instance.Play("ClickSound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      
    }

    public void SettingsEnable()
    {
        AudioManager._instance.Play("ClickSound");
        settingCanvas.SetActive(true);

    }
    
}
