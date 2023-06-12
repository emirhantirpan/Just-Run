using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel, _deathPanel;

    public float health = 3;
    public int numOffHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public bool GameIsPaused = false;

    void Start()
    {
        _pausePanel.SetActive(false);
        _deathPanel.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused == true)
            {
                _pausePanel.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                _pausePanel.SetActive(false);
                Time.timeScale = 1;
            }
        }
        if (health > numOffHearts)
        {
            health = numOffHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOffHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (health == 0)
        {   
            _deathPanel.SetActive(true);
            Time.timeScale = 0;
        }       
    }
    public void PauseButton()
    {
        GameIsPaused = true;
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log("FULL SCREEN");
    }
    public void ContunieButton()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void TryAgainButton()
    {
        SceneManager.LoadScene("Level1");
    }
}