using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _transform;
    [Header("Settings")]
    [SerializeField] private float _xOffset;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _followSpeed;

    public Transform TransformCamera => _transform;
    public float xOffset => _xOffset;
    public float yOffset => _yOffset;
    public float FollowSpeed => _followSpeed;
}
