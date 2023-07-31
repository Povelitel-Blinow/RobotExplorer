using UnityEngine;

public sealed class Root : MonoBehaviour
{
    [SerializeField] private Controller _controller;
    [SerializeField] private Robot _robot;
    [SerializeField] private LocationGenerator _locationGenerator;
    [SerializeField] private Transform _cameraFollow;

    private static Root _root;

    private void Awake()
    {
        Singletone();
        _locationGenerator.GenerateMap();
        Transform robotPos = _locationGenerator.GetRobotPos();
        _robot.Init(robotPos, _controller, _cameraFollow);
        _controller.Init(_robot);
    }

    private void Singletone()
    {
        if(_root == null)
        {
            _root = this;
            return;
        }
        Destroy(gameObject);
    }
}
