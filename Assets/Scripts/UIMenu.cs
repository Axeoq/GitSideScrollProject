using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.CheckSaveFile();
        levelCurrent = GameManager.instance.levelCurrent;
        AddChangeSceneListeners();
        DisableLockedLevel();
        CheckStartPanelExp();
    }

    #region Level Interface Management
    [Header("Level Selection Buttons")]
    public int levelCurrent;
    public Button[] levelButtons;

    public int sceneIndex=0;
    private void AddChangeSceneListeners()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int sceneIndex = i + 1; 
            levelButtons[i].onClick.AddListener(() => GameManager.instance.ChangeScene(sceneIndex));
        }
    }
    private void DisableLockedLevel()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {   
            if (i > levelCurrent)
            {
                levelButtons[i].interactable = false;
            }   
        }
    }
    #endregion 

    #region Panel Management
    [Header("Panel Start")]
    public GameObject startPanel;
    [Header("Panel Level")]
    public GameObject levelPanel;

    public void ShowStartPanel()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
    }

    public void ShowLevelPanel() 
    {
        startPanel.SetActive(false);
        levelPanel.SetActive(true);
        GameManager.instance.isStart = true;
    }
    
    private void CheckStartPanelExp()
    {
        if (isStart())
        {
            ShowLevelPanel();
        }
        else
        {
            ShowStartPanel();
        }
    }

    private bool isStart()
    {
        return GameManager.instance.isStart;
    }
    #endregion
}