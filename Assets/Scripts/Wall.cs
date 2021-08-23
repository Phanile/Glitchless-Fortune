using UnityEngine;
using UnityEngine.Events;

public class Wall : MonoBehaviour
{
    [SerializeField] private GameObject _ricochetEffect;

    [SerializeField] private UnityEvent _bulletReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            CreateRicochetEffect(bullet.GetHitPoint());
            _bulletReached?.Invoke();
        }        
    }

    private void CreateRicochetEffect(Vector3 point)
    {
        Instantiate(_ricochetEffect, point, _ricochetEffect.transform.rotation);
    }
}
