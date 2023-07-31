using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private View _view;
    private Robot _robot;

    public enum DieCause
    {
        fall,
        energyLack
    }

    public void Init(Robot robot)
    {
        _inputManager.Init();
        _robot = robot;
    }

    private void Update()
    {
        _robot.Move(_inputManager.GetMovement());
        _robot.Rotate(_inputManager.GetRotation());
        _robot.Compress(_inputManager.GetCompression());

        if (_inputManager.GetMine())
            Mine();

        if (_inputManager.GetChangeLeadingBody())
            _robot.ChangeLeadingBody();
    }

    private void Mine()
    {
        MinedCristal minedCristal = _robot.Mine();

        if (minedCristal != null)
        {
            
            _view.ShowMinedCristal(minedCristal);
        }
    }

    public void CristallCollectorIsFull()
    {
        _view.CristallCollectorIsFull();
    }

    public void Die(DieCause dieCause)
    {
        _view.Die();
    }
}
