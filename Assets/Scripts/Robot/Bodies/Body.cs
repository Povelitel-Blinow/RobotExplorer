using UnityEngine;

[RequireComponent(typeof(RobotBodyRaycast))]
public class Body : RobotBody
{
    public override void Compress(float compression)
    {
        _linkingPart.Compress(-compression);
    }

    protected override void BecomeLeadingBody()
    {
        _linkingPart.BodyIsLeading();
    }
}
