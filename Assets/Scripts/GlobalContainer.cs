using UnityEngine;

public class GlobalContainer : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private AudioPlayer _audioPlayer;
    [SerializeField] private Transform _canvas;
    [SerializeField] private Camera _camera;

    public static Raycaster Raycaster { get; private set; }
    public static AudioPlayer AudioPlayer { get; private set; }
    public static Transform Canvas { get; private set; }
    public static Camera Camera { get; private set; }

    private void Awake()
    {
        Raycaster = _raycaster;
        AudioPlayer = _audioPlayer;
        Canvas = _canvas;
        Camera = _camera;
    }
}
