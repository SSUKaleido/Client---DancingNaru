using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance = null;
    
    public int stageNum;

    [SerializeField]
    public List<StageInfo> StageInfos = new List<StageInfo>();

    private const string starKey = "Star";
    private const string clearKey = "Cleared";
    private const string openedKey = "Opened";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        CheckLocalDataExist();
    }
    
    /// <summary>
    ///   <para>Check if local data exists if local data don't exist init local data else load local data</para>
    /// </summary>
    void CheckLocalDataExist()
    {
        // Check if project has local data
        int saved = PlayerPrefs.GetInt("Saved");

        if (saved == 1)
        {
            // if saved file exists use 
            LoadLocalData();
        }
        else
        {
            InitLocalData();
            PlayerPrefs.SetInt("Saved", 1);
        }
    }

    /// <summary>
    /// <para>Init Local Data</para>
    /// </summary>
    void InitLocalData()
    {
        for (int i = 0; i < stageNum; i++)
        {
            StageInfo stageInfo = new StageInfo(0, 0, false);
            StageInfos.Add(stageInfo);
        }

        StageInfos[0].Opened = true;
        SaveLocalData();
        
        print("Init Data!");
    }

    /// <summary>
    /// <para> Load Local data </para>
    /// </summary>
    void LoadLocalData()
    {
        for (int i = 0; i < StageInfos.Count; i++)
        {
            string stageNum = i.ToString();

            StageInfos[i].StarCount = PlayerPrefs.GetInt(stageNum + starKey);

            float clearedInfo = PlayerPrefs.GetFloat(stageNum + clearKey);
            int openedInfo = PlayerPrefs.GetInt(stageNum + openedKey);

            StageInfos[i].Cleared = clearedInfo;
            StageInfos[i].Opened = (openedInfo == 1 ? true : false);
        }
        
        print("Load Data!");
    }

    /// <summary>
    /// <para> Save Local data</para>
    /// </summary>
    public void SaveLocalData()
    {
        for (int i = 0; i < StageInfos.Count; i++)
        {
            string stageNum = i.ToString();

            PlayerPrefs.SetInt(stageNum + starKey, StageInfos[i].StarCount);

            int openedInfo = StageInfos[i].Opened ? 1 : 0;
            PlayerPrefs.SetFloat(stageNum + clearKey, StageInfos[i].Cleared);
            PlayerPrefs.SetInt(stageNum + openedKey, openedInfo);
        }
        
        print("Saved Data!");
    }

    /// <summary>
    /// <para> Load Stage Info in stage num return StageInfo </para>
    /// </summary>
    /// <param name="stageNum"></param>
    public StageInfo LoadStageData(int stageNum)
    {
        return StageInfos[stageNum];
    }

    public void SetClearRate(float value)
    {
        StageInfos[stageNum].Cleared = 1;
    }

    public void AddStars(int value)
    {
        StageInfos[stageNum].StarCount += value;
    }
}

[System.Serializable]
public class StageInfo
{
    private int starsCount;
    private float cleared;
    private bool opened;
    public Color stageColor;

    public StageInfo(int stars, float clear, bool open)
    {
        starsCount = stars;
        cleared = clear;
        opened = open;
    }
    
    public int StarCount
    {
        get { return starsCount; }
        set
        {
            starsCount = value;
            DataManager.Instance.SaveLocalData();
        }
    }

    public float Cleared
    {
        get { return cleared; }
        set
        {
            cleared = value; 
            DataManager.Instance.SaveLocalData();
        }
    }

    public bool Opened
    {
        get { return opened; }
        set
        {
            opened = value;
            DataManager.Instance.SaveLocalData();
        }
    }
}