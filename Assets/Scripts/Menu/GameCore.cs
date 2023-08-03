using UnityEngine;
using System;
using System.IO;

public class GameCore : MonoBehaviour
{
    [SerializeField] private RobotStruct[] _robots;
    [SerializeField] private Hangar _hangar;
    [SerializeField] private Store _store;

    [Header("Savings")]
    [SerializeField] private string _saveFileName = "data.json";
    private string _savePath;

    public static GameCore Instance { get; private set; }

    private void Awake()
    {
        _savePath = Path.Combine(Application.dataPath, _saveFileName);

        LoadFromFile();

        Singletone();
    }

    private void Singletone()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        _store.CheckCargo();
    }

    public void StartGame()
    {
        SaveToFile();
        GameToMenuPort.StartGame(_hangar.RobotSelected);
    }

    public void SelectRobot(int num)
    {
        _hangar.SpawnRobot(_robots[num - 1]);
    }

    public void SaveToFile()
    {
        //I wasted 2 hours fixing the GameCoreStruct bug.
        //[System.Serializable] - never forget in HangarStruct/StoreStruct

        GameCoreStuct data = new GameCoreStuct
        {
            HangarData = _hangar.GetData(),
            StoreData = _store.GetData()
        };

        string json = JsonUtility.ToJson(data, true);

        try
        {
            File.WriteAllText(_savePath, json);
        }
        catch
        {
            Debug.Log("Saving Error");
        }
    }

    private void LoadFromFile()
    {
        try
        {
            if (File.Exists(_savePath) == false)
            {
                Debug.Log("No Savings");
                return;
            }
        
            string json = File.ReadAllText(_savePath);
        
            GameCoreStuct gameCoreData = JsonUtility.FromJson<GameCoreStuct>(json);

            _store.LoadData(gameCoreData.StoreData);
            _hangar.LoadData(gameCoreData.HangarData);
        }
        catch(Exception e)
        {
            Debug.Log($"Loading Error {e.Message}");
        }
    }

    private void OnApplicationQuit()
    {
        SaveToFile();
    }

    private void OnApplicationPause(bool pause)
    {
        SaveToFile();
    }
}
