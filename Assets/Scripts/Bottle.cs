using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bottle : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private Image _bottleImage;

    [SerializeField] private UnityEvent _bulletReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Bullet bullet))
        {
            _bulletReached?.Invoke();
        }
    }

    public void InstantiateHit()
    {
        Instantiate(_hitEffect, transform.position, Quaternion.identity);
    }

    public void ReplaceImage(Sprite sprite)
    {
        _bottleImage.sprite = sprite;
    }
}
