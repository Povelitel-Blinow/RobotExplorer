using UnityEngine;
using System.Collections;
using DG.Tweening;

public abstract class Cristal : MonoBehaviour
{
    [SerializeField] protected int _value;
    [SerializeField] protected int _timeToScaleDown;

    public abstract MinedCristal MineIt();

    protected IEnumerator ScalingDown()
    {
        yield return new WaitForSeconds(2);
        transform.DOScale(0.1f, _timeToScaleDown).OnComplete(() => Destroy(gameObject));
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
