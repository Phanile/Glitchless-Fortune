using UnityEngine;

public class GunRotater : MonoBehaviour
{
    public void RotateToTouch(Vector2 touchPosition)
    {
        var lookPos = new Vector3(touchPosition.x - Camera.main.transform.position.x, transform.position.y, touchPosition.y - Camera.main.transform.position.y);
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
    }
}
