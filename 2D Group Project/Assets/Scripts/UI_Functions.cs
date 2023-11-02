using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Functions : MonoBehaviour
{
    public GameObject SettingsMenu;
    void Start()
    {
        SettingsMenu.SetActive(false);
    }

    public void Play()
    {
        SceneLoader(1);
    }

    public void Settings()
    {
        SettingsMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        SettingsMenu.SetActive(false);
    }

    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}