using UnityEngine;

public class ParalaxManager
{
    private Vector3 _backStartPosition;
    private Vector3 _cameraStartPosition;
    private Camera _camera;
    private Transform _backgroundTransform;
    private const float COEF = 0.8f;// set in constructor

    public ParalaxManager(Camera camera, Transform backgroundTransform)
    {
        _backStartPosition = backgroundTransform.position;
        _cameraStartPosition = camera.transform.position;
        _camera = camera;
        _backgroundTransform = backgroundTransform;
    }

    public void Update()
    {
        _backgroundTransform.position = _backStartPosition + (_camera.transform.position - _cameraStartPosition) * COEF;
    }
}
