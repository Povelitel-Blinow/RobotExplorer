using UnityEngine;

public class DigitalEnergyPanel : EnergyPanel
{
    [SerializeField] private Transform _indicator;

    public override void SetEnergyLvl(float percent)
    {
        if(percent >= 0)
            _indicator.localScale = new Vector3(1, 1, percent / 100);
    }
}
    