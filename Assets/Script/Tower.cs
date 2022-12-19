using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]

public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Block> _blocks;

    public event UnityAction<int> SizeUpdated;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Build();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }

        SizeUpdated?.Invoke(_blocks.Count);
    }

    private void OnBulletHit(Block block)
    {
        block.BulletHit -= OnBulletHit;
        _blocks.Remove(block);

        foreach (var blocks in _blocks)
        {
            blocks.transform.position = new Vector3(block.transform.position.x,
                blocks.transform.position.y - block.transform.localScale.y,
                blocks.transform.position.z);
        }

        SizeUpdated?.Invoke(_blocks.Count);
    }
}
