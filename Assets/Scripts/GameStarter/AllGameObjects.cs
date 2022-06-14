using UnityEngine;

public class AllGameObjects : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private CharacterView[] _characterView;
    [SerializeField] private WellView _wellView;
    [SerializeField] private BarrelView _barrelView;
    [SerializeField] private ParticleSystem _barrelCrashEffect;

    public Camera Camera => _camera;
    public SpriteRenderer Background => _background;
    public CharacterView[] CharacterViews => _characterView;
    public WellView WellView => _wellView;
    public BarrelView BarrelView => _barrelView;
    public ParticleSystem BarrelCrashEffect => _barrelCrashEffect;

}
