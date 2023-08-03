using UnityEngine;
using TMPro;

public class StoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _blueCristalText;
    [SerializeField] private TextMeshProUGUI _redCristalText;
    [SerializeField] private TextMeshProUGUI _coinsText;

    public void SetValues(int blue, int red, int coins)
    {
        _blueCristalText.text = blue.ToString();
        _redCristalText.text = red.ToString();
        _coinsText.text = coins.ToString();
    }
}
