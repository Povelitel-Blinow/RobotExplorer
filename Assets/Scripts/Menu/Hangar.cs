using UnityEngine;

public class Hangar : MonoBehaviour
{
    [SerializeField] private Transform _spawnPos;
    private HangarRobot _robot;

    public void SpawnRobot(HangarRobot robot)
    {
        _robot = Instantiate(robot, _spawnPos);
    }
}
