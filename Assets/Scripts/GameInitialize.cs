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
        var inputController = new InputController(inputInitialize.GetInputAxis(), inputInitialize.GetInputSpaceKey());
        var changePlayerController = new ChangePlayerController(gameObjects.CharacterViews, inputInitialize.GetInputSpaceKey());// not work!

        var spriteAnimationController = new SpriteAnimationController(gameObjects.CharacterViews);
        var playerController = new PlayerController(changePlayerController, inputInitialize.GetInputAxis());
        
        
       

        controllers.AddController(inputInitialize);
        controllers.AddController(inputController);
        controllers.AddController(changePlayerController);

        controllers.AddController(paralaxManager);
        controllers.AddController(spriteAnimationController);
        controllers.AddController(playerController);
        
    }
}
