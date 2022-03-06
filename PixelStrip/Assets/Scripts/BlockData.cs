using UnityEngine;

public class BlockData 
{
    private int _durable;
    private Color _color;

    public BlockData(int dutable, Color color)
    {
        _durable = dutable;
        _color = color;
    }

    public BlockData(BlockScriptableData data)
    {
        _durable = data.Durable;
        _color = data.Color;
    }

    public int Durable => _durable;
    public Color Color => _color;

    public void ApplyDamage(int value)
    {
        _durable -= value;
    }
}
