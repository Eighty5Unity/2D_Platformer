using UnityEngine;

internal sealed class GameInitialize
{
    public GameInitialize(Controllers controllers, AllGameObjects gameObjects)
    {
        var paralaxManager = new ParalaxManager(gameObjects.Camera, gameObjects.Background.transform);

        var inputInitialize = new InputInitialize();
        var inputController = new InputController(inputInitialize.GetInputAxis(), inputInitialize.GetInputSpaceKey(), inputInitialize.GetInputUpKey());
        var changePlayerController = new ChangePlayerController(gameObjects.CharacterViews, inputInitialize.GetInputSpaceKey());
        var cameraController = new CameraController(gameObjects.Camera, changePlayerController, gameObjects.YTracksForCamera);
        var spriteAnimationController = new SpriteAnimationController(gameObjects.CharacterViews);
        var playerController = new PlayerController(changePlayerController, inputInitialize.GetInputAxis(), inputInitialize.GetInputUpKey());

        var barrelShooting = new BarrelShooting(gameObjects.BarrelView, gameObjects.WellView, gameObjects.BarrelCrashEffect.gameObject);
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
