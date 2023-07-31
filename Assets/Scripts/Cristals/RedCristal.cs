public class RedCristal : Cristal 
{
    private MinedCristal.CristalType _cristalType = MinedCristal.CristalType.red;

    public override MinedCristal MineIt()
    {
        StartCoroutine(ScalingDown());
        return new MinedCristal(_value, _cristalType);
    }
}
