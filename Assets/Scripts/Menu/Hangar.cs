using UnityEngine;


public class Hangar : MonoBehaviour
{
    [SerializeField] private Transform _spawnPos;

    private HangarRobot _spawnedRobot;
    public RobotStruct RobotSelected { get; private set; }

    public void SpawnRobot(RobotStruct robot)
    {

        if (_spawnedRobot != null)
        {
            Destroy(_spawnedRobot.gameObject);
        }

        RobotSelected = robot;
        _spawnedRobot = Instantiate(robot.HangarRobot, _spawnPos);

        GameCore.Instance.SaveToFile();
    }

    public void LoadData(HangarStruct hangarData)
    {
        if(hangarData.CurrentRobot.HangarRobot != null)
            SpawnRobot(hangarData.CurrentRobot);
    }

    public HangarStruct GetData()
    {
        return new HangarStruct
        {
            CurrentRobot = RobotSelected
        };
    }
}
