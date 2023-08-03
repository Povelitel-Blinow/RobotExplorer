using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private StoreUI _storeUI;

    private int _blueCristals;
    private int _redCristals;
    private int _coinsCristals;

    public void CheckCargo()
    {
        try
        {
            _blueCristals += CargoHandler.BlueCristals;
            _redCristals += CargoHandler.RedCristals;
            UpdateUI();
            CargoHandler.Void();
            GameCore.Instance.SaveToFile();
        }
        catch { }
    }

    public void LoadData(StoreStruct storeData)
    {
        _blueCristals = storeData.BlueCristals;
        _redCristals = storeData.RedCristals;
        _coinsCristals = storeData.CoinsCristals;

        UpdateUI();
    }

    public StoreStruct GetData()
    {
        return new StoreStruct
        {
            BlueCristals = _blueCristals,
            RedCristals = _redCristals,
            CoinsCristals = _coinsCristals
        };
    }

    public void UpdateUI()
    {
        _storeUI.SetValues(_blueCristals, _redCristals, _coinsCristals); // remake later
    }
}
