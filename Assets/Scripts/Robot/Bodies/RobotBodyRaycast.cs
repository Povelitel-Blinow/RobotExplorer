using UnityEngine;

public class RobotBodyRaycast : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private float _rayDownDistance;
    [SerializeField] private float _rayForwardDistance;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _groundAndCristalLayer;

    [Header("Extra")]
    [SerializeField] private bool _isFlyingBody;

    private Tracks _tracks;

    public bool IsGrounded { get; private set; } = true;
    public bool CanMoveForward { get; private set; }
    public bool CanMoveBackward { get; private set; }
    public Transform GroundSurface { get; private set; }

    public void Init(Tracks tracks)
    {
        if (tracks == null)
            throw new System.Exception("Empty _tracks in parent RobotBody");

        _tracks = tracks;
    }

    public void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(_rayPoint.position, -_rayPoint.forward, out hit, _rayDownDistance, _groundLayer))
        {
            IsGrounded = true;
            _tracks.LayDownTracks(hit.point);
            GroundSurface = hit.collider.transform;
        }
        else if(_isFlyingBody)
        {
            IsGrounded = true;
        }
        else
            IsGrounded = false;

        CanMoveForward = !Physics.Raycast(_rayPoint.position, _rayPoint.up, 
            _rayForwardDistance, _groundAndCristalLayer);
        CanMoveBackward = !Physics.Raycast(_rayPoint.position, -_rayPoint.up, 
            _rayForwardDistance, _groundAndCristalLayer);
    }
}
