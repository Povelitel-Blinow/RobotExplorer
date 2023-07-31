using System.Collections.Generic;
using UnityEngine;

public class CristallCollector : MonoBehaviour
{
    private List<MinedCristal> _minedCristals = new List<MinedCristal>();

    public void PutMinedCristal(MinedCristal minedCristal)
    {
        _minedCristals.Add(minedCristal);
    }
}
