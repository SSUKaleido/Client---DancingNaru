using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance = null;
    
    public int stageNum;

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
        
        CheckLocalDataExist();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < StageInfos.Count; i++)
            {
                print(StageInfos[i].StarCount);
                print(StageInfos[i].Opened);
                print(StageInfos[i].Cleared);
            }
        }
    }

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

    void InitLocalData()
    {
        print("Init Data!");
        
        for (int i = 0; i < stageNum; i++)
        {
            StageInfo stageInfo = new StageInfo();
            stageInfo.StarCount = 0;
            stageInfo.Cleared = false;
            stageInfo.Opened = false;

            StageInfos.Add(stageInfo);
        }

        StageInfos[0].Opened = true;
        SaveLocalData();
    }

    void LoadLocalData()
    {
        print("Load Data!");
        
        for (int i = 0; i < StageInfos.Count; i++)
        {
            string stageNum = i.ToString();

            StageInfos[i].StarCount = PlayerPrefs.GetInt(stageNum + starKey);

            int clearedInfo = PlayerPrefs.GetInt(stageNum + clearKey);
            int openedInfo = PlayerPrefs.GetInt(stageNum + openedKey);

            StageInfos[i].Cleared = (clearedInfo == 1 ? true : false);
            StageInfos[i].Opened = (openedInfo == 1 ? true : false);
        }
    }

    void SaveLocalData()
    {
        print("Saved Data!");
        
        for (int i = 0; i < StageInfos.Count; i++)
        {
            string stageNum = i.ToString();

            PlayerPrefs.SetInt(stageNum + starKey, StageInfos[i].StarCount);

            int clearedInfo = StageInfos[i].Cleared ? 1 : 0;
            int openedInfo = StageInfos[i].Opened ? 1 : 0;
            PlayerPrefs.SetInt(stageNum + clearKey, clearedInfo);
            PlayerPrefs.SetInt(stageNum + openedKey, openedInfo);
        }
    }
}

public class StageInfo
{
    private int starsCount;
    private bool cleared;
    private bool opened;

    public int StarCount
    {
        get { return starsCount; }
        set { starsCount = value; }
    }

    public bool Cleared
    {
        get { return cleared; }
        set { cleared = value; }
    }

    public bool Opened
    {
        get { return opened; }
        set { opened = value; }
    }
}