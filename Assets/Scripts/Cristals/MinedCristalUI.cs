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
        float scale = 1;
        while (scale > 0)
        {
            transform.localScale = new Vector3(1, 1, 1) * scale;
            scale -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
