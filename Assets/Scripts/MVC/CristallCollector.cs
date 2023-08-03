using UnityEngine;
using System.Collections.Generic;

public class CristallCollector : MonoBehaviour
{
    private List<MinedCristal> _minedCristals;


    private void Start()
    {
        _minedCristals = new List<MinedCristal>();
    }

    public void PutMinedCristal(MinedCristal minedCristal)
    {
        _minedCristals.Add(minedCristal);
    }

    public int GetBlueCristalsAmount()
    {
        int amount = 0;
        foreach (MinedCristal m in _minedCristals)
        {
            if (m.MinedCristalType == MinedCristal.CristalType.blue)
                amount += m.Value;
        }
        return amount;
    }

    public int GetRedCristalsAmount()
    {
        int amount = 0;
        foreach (MinedCristal m in _minedCristals)
        {
            if (m.MinedCristalType == MinedCristal.CristalType.red)
                amount += m.Value;
        }
        return amount;
    }
}
