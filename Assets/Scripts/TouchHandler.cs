using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private GunRotater _gunRotater;
    [SerializeField] private Camera _camera;

    public Touch Touch { get; private set; }

    private int _firstTouchIndex = 0;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch = Input.GetTouch(_firstTouchIndex);
            _gunRotater.RotateToTouch(GetTouchPosition());
            if (_weapon.CanShoot)
            {
                _raycaster.RayCast();
            }
            if (Touch.phase == TouchPhase.Ended)
            {
                _weapon.Shoot();
            }
        }
    }

    public Vector2 GetTouchPosition()
    {
        return _camera.ScreenToWorldPoint(Touch.position);
    }
}
