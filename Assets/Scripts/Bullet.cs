using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _currentIndex;
    [SerializeField] private float _speed;

    private Vector3[] _hitPositions;

    private void OnEnable()
    {
        _hitPositions = GlobalContainer.Raycaster.GetHitPoints();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _hitPositions[_currentIndex], Time.deltaTime * _speed);

        if (_currentIndex != 0)
        {
            var look = Quaternion.LookRotation(_hitPositions[_currentIndex] - _hitPositions[_currentIndex - 1]);
            transform.rotation = Quaternion.Euler(90, look.eulerAngles.y, 0);
        }
        
        if (transform.position == _hitPositions[_currentIndex])
        {
            if (_currentIndex + 1 >= _hitPositions.Length)
            {
                return;
            }
            _currentIndex += 1;
        }
    }
    public Vector3 GetHitPoint()
    {
        return _hitPositions[_currentIndex];
    }
}
