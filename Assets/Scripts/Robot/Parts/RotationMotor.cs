using UnityEngine;

public class RotationMotor : MonoBehaviour
{
    [SerializeField] private Transform _linkingPartPos;
    //Add Scale Constraint in Inspector!!!

    public Transform GetLinkingPartPos()
    {
        return _linkingPartPos;
    }
}
