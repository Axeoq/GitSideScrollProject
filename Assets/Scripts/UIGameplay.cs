using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour 
{   
    
    [Header ("Scene Index")]
    [SerializeField] private int sceneIndex = 0;

    [Header ("Gameplay Buttons")]
    public Button buttonResume;
    public Button buttonPause;
    public Button buttonMenu;

    private void Start() 
    {
        buttonMenu.onClick.AddListener(() => GameManager.instance.ChangeScene(sceneIndex));
        buttonPause.onClick.AddListener(HandleButtonClick);
        buttonResume.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        if(GameManager.instance.isPaused)
        {
            GameManager.instance.Resume();
            buttonPause.gameObject.SetActive(true);
            buttonResume.gameObject.SetActive(false);
        }
        else
        {
            GameManager.instance.Pause();
            buttonPause.gameObject.SetActive(false);
            buttonResume.gameObject.SetActive(true);
        }
    }

}