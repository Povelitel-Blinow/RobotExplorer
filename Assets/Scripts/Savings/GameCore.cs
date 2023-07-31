using UnityEngine;

public class GameCore : MonoBehaviour
{
    [SerializeField] private RobotStruct[] _robots;
    [SerializeField] private Hangar _hangar;

    private void Awake()
    {
        _hangar.SpawnRobot(_robots[1].HangarRobot);
    }
}
