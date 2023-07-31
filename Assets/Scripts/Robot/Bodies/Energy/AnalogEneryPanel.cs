using UnityEngine;

public class AnalogEneryPanel : EnergyPanel
{
    [SerializeField] private GameObject[] _lamps;

    public override void SetEnergyLvl(float percent)
    {
        switch (percent)
        {
            case <= 0:
                _lamps[4].SetActive(false);
                break;

            case < 20:
                _lamps[3].SetActive(false);
                break;

            case < 40:
                _lamps[2].SetActive(false);
                break;

            case < 60:
                _lamps[1].SetActive(false);
                break;

            case < 80:
                _lamps[0].SetActive(false);
                break;
        }
    }
}
