using System.Collections.Generic;
using UnityEngine;

public class AllGameObjects : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private CharacterView[] _characterView;
    [SerializeField] private WellView _wellView;
    [SerializeField] private List<BarrelView> _barrelViews;

    public Camera Camera => _camera;
    public SpriteRenderer Background => _background;
    public CharacterView[] CharacterViews => _characterView;
    public WellView WellView => _wellView;
    public List<BarrelView> BarrelViews => _barrelViews;
}
