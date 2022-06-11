using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class GameInitialize
{
    public GameInitialize(Controllers controllers, AllGameObjects gameObjects)
    {
        Camera camera = gameObjects.Camera;
        var paralaxManager = new ParalaxManager(camera, gameObjects.Background.transform);
        var spriteAnimationController = new SpriteAnimationController(gameObjects.CharacterViews);
        var playerController = new PlayerController(gameObjects.CharacterViews[0], spriteAnimationController.SpriteAnimations[0]);// make spriteAnimation in Character
        var changePlayerController = new ChangePlayerController(gameObjects.CharacterViews, playerController);


        controllers.AddController(paralaxManager);
        controllers.AddController(spriteAnimationController);
        controllers.AddController(playerController);
        controllers.AddController(changePlayerController);
    }
}
