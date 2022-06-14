using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class GameInitialize
{
    public GameInitialize(Controllers controllers, AllGameObjects gameObjects)
    {
        Camera camera = gameObjects.Camera;
        var paralaxManager = new ParalaxManager(camera, gameObjects.Background.transform);

        var inputInitialize = new InputInitialize();
        var inputController = new InputController(inputInitialize.GetInputAxis(), inputInitialize.GetInputSpaceKey(), inputInitialize.GetInputUpKey());
        var changePlayerController = new ChangePlayerController(gameObjects.CharacterViews, inputInitialize.GetInputSpaceKey());

        var spriteAnimationController = new SpriteAnimationController(gameObjects.CharacterViews);
        var playerController = new PlayerController(changePlayerController, inputInitialize.GetInputAxis(), inputInitialize.GetInputUpKey());

        var barrelShooting = new BarrelShooting(gameObjects.BarrelView, gameObjects.WellView, gameObjects.BarrelCrashEffect.gameObject);
        controllers.AddController(inputInitialize);
        controllers.AddController(inputController);
        controllers.AddController(changePlayerController);

        controllers.AddController(paralaxManager);
        controllers.AddController(spriteAnimationController);
        controllers.AddController(playerController);

        controllers.AddController(barrelShooting);
        controllers.AddController(barrelShooting.BarrelFactory.BarrelPool);
        controllers.AddController(barrelShooting.BarrelCrashFactory.BarrelCrashPool);
    }
}
