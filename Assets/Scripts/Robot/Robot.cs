using System;
using System.Collections;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField] private RobotBody _mainBody;
    [SerializeField] private RobotBody _body;
    [SerializeField] private LinkingPart _linkingPart;
    [SerializeField] private EnergyPanel[] _energyPanels;

    [SerializeField] private float _cristalCollectorCapacity;
    [SerializeField] private float _miningTime;
    [SerializeField] private float _maxEnergy;
    private float _currentEnergy;

    private RobotBody _currentLeadingBody;
    private RobotBody _currentChildBody;

    private bool _canMove = true;

    public Action CristallCollectorIsFull;

    public void Init(Transform robotPos, Controller controller, Transform cameraFollow)
    {
        transform.position = robotPos.position;

        _linkingPart.Init(_mainBody, _body, cameraFollow);
        _mainBody.Init(_linkingPart);
        _body.Init(_linkingPart);

        _currentLeadingBody = _mainBody;
        _currentChildBody = _body;

        _currentLeadingBody.SetIsleadingBody(true);
        _currentChildBody.SetIsleadingBody(false);

        _body.Die += controller.Die;
        _mainBody.Die += controller.Die;

        CristallCollectorIsFull += controller.CristallCollectorIsFull;
        _currentEnergy = _maxEnergy;
    }

    private void FixedUpdate()
    {
        _currentEnergy -= Time.fixedDeltaTime;

        float percent = (_currentEnergy / _maxEnergy) * 100;
        foreach(EnergyPanel e in _energyPanels)
            e.SetEnergyLvl(percent);

        if (percent <= 0)
            _currentLeadingBody.DieFromEnergyLack();
    }

    public void Move(float movement)
    {
        if(_canMove)
            _currentLeadingBody.Move(movement);
    }

    public void Rotate(float rotation)
    {
        _currentLeadingBody.Rotate(rotation);
    }

    public void Compress(float compression)
    {
        _currentLeadingBody.Compress(compression);
    }

    public MinedCristal Mine()
    {
        if (_cristalCollectorCapacity > 0)
        {
            if (_currentLeadingBody.TryGetComponent(out ICanMine mineBody))
            {
                MinedCristal minedCristal = mineBody.Mine();
                if (minedCristal != null)
                {
                    StartCoroutine(Mining());

                    _cristalCollectorCapacity -= minedCristal.Value;
                    if (_cristalCollectorCapacity <= 0)
                    {
                        CristallCollectorIsFull?.Invoke();
                    }
                    return minedCristal;
                }
            }
        }
        else
            CristallCollectorIsFull?.Invoke();
        return null;
    }

    public void ChangeLeadingBody()
    {
        if(_canMove && _currentChildBody.TryBecomeLeadingBody())
        {
            RobotBody tmp = _currentLeadingBody;
            _currentLeadingBody = _currentChildBody;
            _currentChildBody = tmp;
            _currentChildBody.SetIsleadingBody(false);
        }
    }

    private IEnumerator Mining()
    {
        _canMove = false;
        yield return new WaitForSeconds(_miningTime);
        _canMove = true;
    }
}
