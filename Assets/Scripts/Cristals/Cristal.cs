using UnityEngine;
using System.Collections;
using DG.Tweening;

public abstract class Cristal : MonoBehaviour
{
    [SerializeField] protected int _value;

    public abstract MinedCristal MineIt();

    protected IEnumerator ScalingDown()
    {
        yield return new WaitForSeconds(2);
        transform.DOScale(0.1f, 3).OnComplete(() => Destroy(gameObject));
    }
}
