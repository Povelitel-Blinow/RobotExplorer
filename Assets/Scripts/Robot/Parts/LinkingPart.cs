using UnityEngine;

public class LinkingPart : MonoBehaviour
{
    [SerializeField] private RotationMotor _rotationMotor1;
    [SerializeField] private RotationMotor _rotationMotor2;
    [SerializeField] private Transform _midPos;

    [SerializeField] private float _compressionSpeed;
    [SerializeField] private float _minCompression;

    private RobotBody _mainBody;
    private RobotBody _body;

    private Transform _rotationPos1;
    private Transform _rotationPos2;

    public void Init(RobotBody main, RobotBody body, Transform cameraFollow)
    {
        _mainBody = main;
        _body = body;

        cameraFollow.transform.position = _midPos.position;
        cameraFollow.transform.parent = _midPos;

        _rotationPos1 = _rotationMotor1.GetLinkingPartPos();
        _rotationPos2 = _rotationMotor2.GetLinkingPartPos();
    }

    public void MainBodyIsLeading()
    {
        _rotationMotor1.transform.parent = _mainBody.transform;
        transform.parent = _rotationMotor1.transform;
        transform.position = _rotationPos1.transform.position;
        transform.localScale = new Vector3(1, 1, Mathf.Abs(transform.localScale.z));
        _rotationMotor2.transform.parent = transform;
    }

    public void BodyIsLeading()
    {

        _rotationMotor2.transform.parent = _body.transform;
        transform.parent = _rotationMotor2.transform;
        transform.position = _rotationPos2.transform.position;
        transform.localScale = new Vector3(1, 1, -Mathf.Abs(transform.localScale.z));
        _rotationMotor1.transform.parent = transform;

    }

    public void Compress(float compression)
    {
        float z = transform.localScale.z + compression * _compressionSpeed * Time.deltaTime;
        if (Mathf.Abs(z) >= _minCompression && Mathf.Abs(z) <= 1)
            transform.localScale = new Vector3(1, 1, z);
    }
}
