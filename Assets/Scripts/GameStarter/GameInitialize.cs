using UnityEngine;

internal sealed class GameInitialize
{
    public GameInitialize(Controllers controllers, AllGameObjects allPrefabs)
    {
        var paralaxManager = new ParalaxManager(allPrefabs.Camera, allPrefabs.Background.transform);
        var inputInitialize = new InputInitialize();
        var inputController = new InputController(inputInitialize.GetInputAxis(), inputInitialize.GetInputSpaceKey(), inputInitialize.GetInputUpKey(), inputInitialize.GetInputEKey());
        var changePlayerController = new ChangePlayerController(allPrefabs.CharacterViews, inputInitialize.GetInputSpaceKey());
        var cameraController = new CameraController(allPrefabs.Camera, changePlayerController, allPrefabs.YTracksForCamera);
        var spriteAnimationController = new SpriteAnimationController(allPrefabs.CharacterViews);
        var playerController = new PlayerController(changePlayerController, inputInitialize.GetInputAxis(), inputInitialize.GetInputUpKey(), inputInitialize.GetInputEKey());
        var barrelShooting = new BarrelShooting(allPrefabs.BarrelView, allPrefabs.WellView, allPrefabs.BarrelCrashEffect.gameObject);

        controllers.AddController(inputInitialize);
        controllers.AddController(inputController);
        controllers.AddController(changePlayerController);
        controllers.AddController(cameraController);
        controllers.AddController(paralaxManager);
        controllers.AddController(spriteAnimationController);
        controllers.AddController(playerController);
        controllers.AddController(barrelShooting);
    }
}
