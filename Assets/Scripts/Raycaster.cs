using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private Weapon _weapon;

    [Header("RaycastSettings")]
    [SerializeField] private int _maxReflectionCount;
    [SerializeField] private float _maxLength;

    private Ray _ray;
    private RaycastHit _hit;

    public void RayCast()
    {
        float remainingLength = _maxLength;

        _ray = new Ray(_muzzle.position, _muzzle.forward);

        _lineRenderer.positionCount = 1;
        _lineRenderer.SetPosition(0, _muzzle.position);

        for (int i = 0; i < _maxReflectionCount + 1; i++)
        {
            if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, remainingLength, GameLayers.WallMask))
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _hit.point);
                remainingLength -= Vector3.Distance(_ray.origin, _hit.point);
                if (i != _maxReflectionCount)
                {
                    _ray = new Ray(_hit.point, Vector3.Reflect(_ray.direction * remainingLength, _hit.normal));
                }
            }
            else
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _ray.origin + _ray.direction * remainingLength);
                break;
            }

            if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, remainingLength, GameLayers.BarrelMask))
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _hit.point);
                break;
            }
        }
    }

    public void Enable()
    {
        RayCast();
    }

    public Vector3[] GetHitPoints()
    {
        Vector3[] pos = new Vector3[_lineRenderer.positionCount];
        _lineRenderer.GetPositions(pos);
        return pos;
    }
}
