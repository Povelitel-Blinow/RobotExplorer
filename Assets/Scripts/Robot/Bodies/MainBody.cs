using UnityEngine;

[RequireComponent(typeof(RobotBodyRaycast))]
public class MainBody : RobotBody
{
    public override void Compress(float compression)
    {
        _linkingPart.Compress(compression); // check out Body script then it makes sense
    }

    protected override void BecomeLeadingBody()
    {
        _linkingPart.MainBodyIsLeading();
    }
}
