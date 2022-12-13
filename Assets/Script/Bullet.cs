using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _bounceForse;
    [SerializeField] private float _bounceRadius;

    private Vector3 _moveDerection;

    private void Start()
    {
        _moveDerection = Vector3.forward;
    }

    private void Update()
    {
        transform.Translate(_moveDerection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }
        if (other.TryGetComponent(out Abstacle abstacle))
        {
            Bounce();
        }
    }

    private void Bounce()
    {
        _moveDerection = Vector3.back + Vector3.up;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(_bounceForse, transform.position + new Vector3(0, -1, -1), _bounceRadius);
    }
}
