using UnityEngine;
using UnityEngine.InputSystem;

public sealed class InputManager : MonoBehaviour
{
    private PlayerInput _inputActions;
    private PlayerInput.RobotActions _robotActions;

    private static InputManager _instance;

    public void Init()
    {
        Singletone();
        _inputActions = new PlayerInput();
        _robotActions = _inputActions.Robot;
        _robotActions.Enable();
    }

    private void Singletone()
    {
        if (_instance == null)
        {
            _instance = this;
            return;
        }
        Destroy(gameObject);
    }
    
    public float GetMovement()
    {
        return _robotActions.Move.ReadValue<float>();
    }

    public float GetRotation()
    {
        return _robotActions.Rotate.ReadValue<float>();
    }

    public float GetCompression()
    {
        return _robotActions.Compress.ReadValue<float>();
    }

    public bool GetMine()
    {
        return _robotActions.Mine.WasPressedThisFrame();
    }

    public bool GetChangeLeadingBody()
    {
        return _robotActions.ChangeLeadingBody.WasPressedThisFrame();
    }

    private void OnDisable()
    {
        _robotActions.Disable();
    }
}
