using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    public event UnityAction<Block> BulletHit;

    [SerializeField] private ParticleSystem _destroyEffect;

    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    
    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }

    public void Break()
    {
        BulletHit?.Invoke(this);
        ParticleSystemRenderer renderer = Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        renderer.material.color = _meshRenderer.material.color;
        Destroy(gameObject);
    }
}