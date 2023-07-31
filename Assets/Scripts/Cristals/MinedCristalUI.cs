using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MinedCristalUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cristalText;

    public void Init(int amount)
    {
        _cristalText.text = amount.ToString();
        StartCoroutine(FadingAway());
    }

    private IEnumerator FadingAway()
    {
        yield return new WaitForSeconds(1);
        transform.DOScale(0, 5).OnComplete(() => Destroy(gameObject));
    }
}
