using System.Collections.Generic;
using UnityEngine;

public class CensorBlockPresenter : MonoBehaviour
{
    [SerializeField] private List<Block> _blockGroup;

    private void Start()
    {
        InitBlockGroupFromChildren();
        _blockGroup.ForEach(x => x.OnDestroyed += DestroyBlock);
    }

    //TODO change initialize censor group
    private void InitBlockGroupFromChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            Block blockComponent;

            if (child.TryGetComponent<Block>(out blockComponent))
            {
                _blockGroup.Add(blockComponent);
            }
        }
    }

    private void DestroyBlock(Block block)
    {
        _blockGroup.Remove(block);
        Destroy(block.gameObject);
    }
}
