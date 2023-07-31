public class BlueCristal : Cristal 
{
    private MinedCristal.CristalType _cristalType = MinedCristal.CristalType.blue;

    public override MinedCristal MineIt()
    {
        StartCoroutine(ScalingDown());
        return new MinedCristal(_value, _cristalType);
    }
}
