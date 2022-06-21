using UnityEngine;

public class AllGameObjects : MonoBehaviour
{
    [SerializeField] private CameraView _camera;
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private CharacterView[] _characterView;
    [SerializeField] private WellView _wellView;
    [SerializeField] private BarrelShootingView _shootingPoint;
    [SerializeField] private BarrelView _barrelView;
    [SerializeField] private ParticleSystem _barrelCrashEffect;
    [SerializeField] private Transform[] _yTracksForCamera;
    [SerializeField] private UIView _uiView;

    public CameraView Camera => _camera;
    public Transform[] YTracksForCamera => _yTracksForCamera;
    public SpriteRenderer Background => _background;
    public CharacterView[] CharacterViews => _characterView;
    public WellView WellView => _wellView;
    public BarrelShootingView ShootingPoint => _shootingPoint;
    public BarrelView BarrelView => _barrelView;
    public ParticleSystem BarrelCrashEffect => _barrelCrashEffect;
    public UIView UIVIew => _uiView;
}
