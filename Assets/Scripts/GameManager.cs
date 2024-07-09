using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    #region Game Manager
    public static GameManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    #endregion 

    #region Game Management 
    public bool isPaused;

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene (sceneIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true; 
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    #endregion

    #region Level Manager 
    LevelData levelData;

    public int levelCurrent;

    public void CheckSaveFile()
    {
        if(File.Exists(Application.dataPath + "/Level,json")) LoadLevel();
        else SaveLevel();
    } 

    private void SaveLevel()
    {
        levelData = new LevelData();
        levelData.level = levelCurrent;
        string json = JsonUtility.ToJson(levelData, true);
        File.WriteAllText(Application.dataPath + "/Level.json", json);
    }

    private void LoadLevel()
    {
        string json;
        json = File.ReadAllText(Application.dataPath + "/Level.json");
        LevelData levelData = JsonUtility.FromJson<LevelData>(json);
        levelCurrent = levelData.level;
    }

    private void CheckLevel()
    {
        LoadLevel();
        levelCurrent = levelData.level;
    }

    public void ChangeLevel(int newLevelUnlocked)
    {
        levelCurrent = newLevelUnlocked;
        {
            levelCurrent = newLevelUnlocked;
            SaveLevel();
        }
    }

    public void ResetLevel()
    {
        levelCurrent = 0;
        SaveLevel();
    }
    #endregion 

    #region Panel Management Data
    public bool isStart;
    #endregion
}
