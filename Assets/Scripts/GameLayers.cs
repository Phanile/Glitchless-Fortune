using UnityEngine;

public class GameLayers : MonoBehaviour
{
    [Header("Masks")]
    [SerializeField] private LayerMask _wallMask;
    [SerializeField] private LayerMask _barrelMask;

    public static LayerMask WallMask { get; private set; }
    public static LayerMask BarrelMask { get; private set; }

    public static int indexOfWallMask { get; } = 7;
    public static int indexOfBarrelMask { get; } = 8;

    private void Awake()
    {
        WallMask = _wallMask;
        BarrelMask = _barrelMask;
    }
}
