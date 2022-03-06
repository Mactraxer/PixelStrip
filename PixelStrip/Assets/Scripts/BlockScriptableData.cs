using UnityEngine;

[CreateAssetMenu(menuName = "New Block", fileName = "Block")]
public class BlockScriptableData : ScriptableObject
{

    [SerializeField] private int _durable;
    [SerializeField] private Color _color;

    public int Durable => _durable;
    public Color Color => _color;
}
