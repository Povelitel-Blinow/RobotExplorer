using System;
using UnityEngine;

[RequireComponent(typeof(RobotBodyRaycast))]
public abstract class RobotBody : MonoBehaviour
{
    [Header("Parts")]
    [SerializeField] private GameObject _rotationMotor;
    [SerializeField] private GameObject _leadingBodyInd;
    [SerializeField] private Tracks _tracks;

    [Header("Components")]
    [SerializeField] private RobotBodyRaycast _bodyRaycast;

    [Header("Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
   
    private bool _isCurrentLeadingBody;
    protected LinkingPart _linkingPart;

    public Action<Controller.DieCause> Die;

    public void Init(LinkingPart linkingPart)
    {
        _linkingPart = linkingPart;

        if (_bodyRaycast == null)
            throw new System.Exception("Empty _bodyRaycast");
        _bodyRaycast.Init(_tracks);
    }

    public void Update()
    {

        if(_isCurrentLeadingBody == false)
        {
            transform.position = _rotationMotor.transform.position;
        }
        else
        {
            if (_bodyRaycast.IsGrounded == false)
                DieFromFalling();
            else
                transform.parent = _bodyRaycast.GroundSurface;
        }
    }

    private void DieFromFalling()
    {
        Die?.Invoke(Controller.DieCause.fall);
    }

    public void DieFromEnergyLack()
    {
        Die?.Invoke(Controller.DieCause.energyLack);
    }

    public void Move(float movement) 
    {
        if((movement > 0 && _bodyRaycast.CanMoveForward) 
            || (movement < 0 && _bodyRaycast.CanMoveBackward))
            transform.position += transform.up * movement * _moveSpeed * Time.deltaTime;
    }

    public void Rotate(float rotation)
    {
        _rotationMotor.transform.Rotate(-_rotationMotor.transform.right
            * _rotateSpeed * rotation * Time.deltaTime, Space.Self);
    }

    public abstract void Compress(float compression);

    public bool TryBecomeLeadingBody()
    {
        if (_bodyRaycast.IsGrounded)
        {
            SetIsleadingBody(true);
            return true;
        }
        return false;
    }

    protected abstract void BecomeLeadingBody();

    public void SetIsleadingBody(bool state)
    {
        if (state)
            BecomeLeadingBody();
        _isCurrentLeadingBody = state;
        _leadingBodyInd.SetActive(state);
    }
}
