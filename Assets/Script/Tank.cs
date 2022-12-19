using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTamplate;
    [SerializeField] private float _delayBetweenShoots;
    [SerializeField] private float recoil;

    private float _timerAfterShoot;

    private void Update()
    {
        _timerAfterShoot += Time.deltaTime;

        if(Input.GetMouseButton(0))
        {
            if (_timerAfterShoot > _delayBetweenShoots)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - recoil, _delayBetweenShoots / 2).SetLoops(2, LoopType.Yoyo);
                _timerAfterShoot = 0;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletTamplate, _shootPoint.position, Quaternion.identity);
    }
}
