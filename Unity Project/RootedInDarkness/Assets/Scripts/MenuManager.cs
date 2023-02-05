using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public Image startImage;
    public Image exitImage;
    public GameObject ExitPanel;
    public Image YesImage;
    public Image NoImage;

    public void StartButtonSelected()
    {
        startImage.enabled = true;
        
    }
    public void StartButtonDeselected()
    {
        startImage.enabled = false;
    }
    public void ExitButtonSelected()
    {
        exitImage.enabled = true;
    }

    public void ExitButtonDeselected()
    {
        exitImage.enabled = false;
    }

    public void ChangeSceneToGame()
    {
        SceneManager.LoadScene(2);
    }

    
    public void EnableDisableExitPanel()
    {
        ExitPanel.SetActive(!ExitPanel.activeSelf);
    }

    public void NoButtonSelected()
    {
        NoImage.enabled = true;
    }

    public void NoButtonDeselected()
    {
        NoImage.enabled = false;
    }

    public void YesButtonSelected()
    {
        YesImage.enabled = true;
    }

    public void YesButtonDeselected()
    {
        YesImage.enabled = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
