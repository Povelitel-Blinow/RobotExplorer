using UnityEngine;
using DG.Tweening;

public class MovingGround : MonoBehaviour
{
    [SerializeField] private int _targetZOffset;
    [SerializeField] private int _targetYOffset;
    [SerializeField] private float _time;

    private Vector3 _defaultPos;

    private void Start()
    {
        _defaultPos = transform.position;
        transform.DOMove(_defaultPos + new Vector3(0, _targetYOffset, _targetZOffset), _time)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
