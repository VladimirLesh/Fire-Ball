using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder: MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Block _block;
    public Transform _buildPoint;

    private List<Block> _blocks;

    public List<Block> Build()
    {
        _blocks = new List<Block>();

        Transform currentPoint = _buildPoint;

        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }
        return _blocks;
    }

    private Block BuildBlock(Transform _currentBuildPoint)
    {
        return Instantiate(_block, GetBuildPoint(_currentBuildPoint), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform _currentBuildPoint)
    {
        Debug.Log($"Position Y = {_currentBuildPoint.position.y}");
        Debug.Log($"LocalScale Y / 2 = {_currentBuildPoint.localScale.y / 2}");
        Debug.Log($"Block LocaScale Y / 2 = {_block.transform.localScale.y / 2}");

        return new Vector3(_buildPoint.position.x,
            _currentBuildPoint.position.y +
            _currentBuildPoint.localScale.y / 2f +
            _block.transform.localScale.y / 2f,
            _buildPoint.position.z);
        
    }
}
