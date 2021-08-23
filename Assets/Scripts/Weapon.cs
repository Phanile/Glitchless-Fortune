using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private float _reloadTime;

    [Header("Links")]
    [SerializeField] private Transform _muzzle;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _shooted;

    public bool CanShoot { get; private set; } = true;

    public void Shoot()
    {
        if (CanShoot)
        {
            _shooted?.Invoke();
            StartCoroutine(Reload());
        }
    }

    public void InstantiateOnMuzzle(GameObject entity)
    {
        Instantiate(entity, _muzzle.transform.position, entity.transform.rotation);
    }

    private IEnumerator Reload()
    {
        CanShoot = false;
        yield return new WaitForSeconds(_reloadTime);
        _raycaster.Enable();
        CanShoot = true;
        _line.enabled = true;
    }
}
