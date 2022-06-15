using UnityEngine;

public class ParalaxManager : ILateUpdate
{
    private Vector3 _backStartPosition;
    private Vector3 _cameraStartPosition;
    private CameraView _camera;
    private Transform _backgroundTransform;
    private const float COEF = 0.8f;// set in constructor

    public ParalaxManager(CameraView camera, Transform backgroundTransform)
    {
        _backStartPosition = backgroundTransform.position;
        _cameraStartPosition = camera.TransformCamera.position;
        _camera = camera;
        _backgroundTransform = backgroundTransform;
    }

    public void LateUpdate(float deltaTime)
    {
        _backgroundTransform.position = _backStartPosition + (_camera.TransformCamera.position - _cameraStartPosition) * COEF;
    }
}
