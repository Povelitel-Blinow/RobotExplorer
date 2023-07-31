using UnityEngine;
using Cinemachine;

public class HangarCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _RobotCamera;
    [SerializeField] private CinemachineVirtualCamera _TracksCamera;
    [SerializeField] private CinemachineVirtualCamera _RotMotorCamera;

    private void Start()
    {
        ShowRobot();
    }

    public void ShowRobot()
    {
        TurnOff();
        _RobotCamera.enabled = true;
    }

    public void ShowTracks()
    {
        TurnOff();
        _TracksCamera.enabled = true;

    }

    public void ShowRotMotor()
    {
        TurnOff();
        _RotMotorCamera.enabled = true;

    }

    private void TurnOff()
    {
        _RobotCamera.enabled = false;
        _TracksCamera.enabled = false;
        _RotMotorCamera.enabled = false;
    }
}
