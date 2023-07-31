using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] private GameObject _diePanel;
    [SerializeField] private GameObject _isFullPanel;

    [SerializeField] private Transform _cristalUISpawnPos;
    [SerializeField] private MinedCristalUI _minedBlueCristal;
    [SerializeField] private MinedCristalUI _minedRedCristal;

    public void ShowMinedCristal(MinedCristal minedCristal)
    {
        int amount = minedCristal.Value;
        switch (minedCristal.MinedCristalType)
        {
            case MinedCristal.CristalType.blue:
                Spawn(_minedBlueCristal, amount);
                break;

            case MinedCristal.CristalType.red:
                Spawn(_minedRedCristal, amount);
                break;
        }
    }

    private void Spawn(MinedCristalUI minedCristalUI, int amount)
    {
        Instantiate(minedCristalUI, _cristalUISpawnPos).Init(amount);
    }

    public void CristallCollectorIsFull()
    {
        _isFullPanel.SetActive(true);
    }

    public void Die()
    {
        _diePanel.SetActive(true);
    }
}
