public class MinedCristal
{
    public int Value { get; private set; }
    public CristalType MinedCristalType { get; private set; }
    public enum CristalType
    {
        blue,
        red
    }

    public MinedCristal(int value, CristalType cristalType)
    {
        Value = value;
        MinedCristalType = cristalType;
    }
}
