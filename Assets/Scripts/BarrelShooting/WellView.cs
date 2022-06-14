using UnityEngine;

public class WellView : MonoBehaviour
{
    [SerializeField] private Transform _barrelShootPoint;

    [Header("ShootingSettings")]
    [SerializeField][Range(-0.05f, 0.05f)] private float _leftRight;
    [SerializeField][Range(0.03f, 0.09f)] private float _downUp;

    public Transform BarrelShootPoint => _barrelShootPoint;
    public float LeftRight => _leftRight;
    public float DownUp => _downUp;
}
