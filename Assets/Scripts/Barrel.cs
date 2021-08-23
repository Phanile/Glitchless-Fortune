using UnityEngine;
using UnityEngine.Events;

public class Barrel : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;

    [SerializeField] private UnityEvent _bulletReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            _bulletReached?.Invoke();
            bullet.gameObject.SetActive(false);
        }
    }

    public void InstantiateExplosion()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
    }
}
