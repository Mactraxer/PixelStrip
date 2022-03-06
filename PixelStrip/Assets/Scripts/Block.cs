using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private BlockScriptableData _initData;
    [SerializeField] private BlockTrigger _trigger;
    private BlockData _data;

    public Action<Block> OnDestroyed;

    private void Awake()
    {
        _trigger.OnTriggered += ApplyDamage;
    }

    private void Start()
    {
        _data = new BlockData(_initData);
    }

    private void OnDisable()
    {
        _trigger.OnTriggered -= ApplyDamage;
    }

    private void ApplyDamage(Rigidbody rigidbody)
    {
        _data.ApplyDamage(1);
        if (_data.Durable <= 0)
        {
            OnDestroyed?.Invoke(this);
        }
    }
}
