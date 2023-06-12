using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject _mainPannel, _settingsPanel;
    [SerializeField] AudioSource _as;
    [SerializeField] Slider _sl;
    void Start()
    {
        _mainPannel.SetActive(true);
        _settingsPanel.SetActive(false);

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            Load();
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void SettingsButton()
    {
        _mainPannel.SetActive(false);
        _settingsPanel.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void BackButton()
    {
        _mainPannel.SetActive(true);
        _settingsPanel.SetActive(false);
    }
    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log("FULL SCREEN");
    }
    public void SoundBar()
    {
        AudioListener.volume = _sl.value;
        Save();
    }
    private void Load()
    {
        _sl.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume",_sl.value);
    }
}
