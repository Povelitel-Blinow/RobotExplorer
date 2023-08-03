using UnityEngine;

[RequireComponent(typeof(MiningTool))]
public class MiningMainBody : MainBody, ICanMine
{
    [SerializeField] private MiningTool _miningTool;

    public MinedCristal Mine()
    {
        return _miningTool.TryMine();
    }
}