using UnityEngine;

public class CameraController : ILateUpdate
{
    private CameraView _camera;
    private ChangePlayerController _changePlayerController;
    private Transform[] _yTrack;

    public CameraController(CameraView camera, ChangePlayerController player, Transform[] yTrack)
    {
        _camera = camera;
        _changePlayerController = player;
        _yTrack = yTrack;
    }

    public void LateUpdate(float deltaTime)
    {
        var playerPosition = _changePlayerController.CurrentCharacter.transform.position;
        var xTarget = playerPosition.x + _camera.xOffset;
        var yTarget = _camera.TransformCamera.position.y + _camera.yOffset;

        for (int i = 0; i < _yTrack.Length - 1; i++)
        {
            if(playerPosition.y <= _yTrack[0].position.y)
            {
                xTarget = _camera.TransformCamera.position.x;
                yTarget = _yTrack[i].position.y + _camera.yOffset;
                break;
            }
            else if(_yTrack[i].position.y < playerPosition.y && playerPosition.y < _yTrack[i + 1].position.y)
            {
                yTarget = _yTrack[i].position.y + _camera.yOffset;
                break;
            }
        }

        var xNew = Mathf.Lerp(_camera.TransformCamera.position.x, xTarget, deltaTime * _camera.FollowSpeed);
        var yNew = Mathf.Lerp(_camera.TransformCamera.position.y, yTarget, deltaTime * _camera.FollowSpeed);

        _camera.transform.position = new Vector3(xNew, yNew, _camera.transform.position.z);
    }
}
