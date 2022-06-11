using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationController : IUpdate
{
    private List<SpriteAnimation> _spriteAnimations = new List<SpriteAnimation>();

    public List<SpriteAnimation> SpriteAnimations => _spriteAnimations;

    public SpriteAnimationController(CharacterView[] characterViews)
    {
        foreach(var characterView in characterViews)
        {
            var characterSpriteAnimation = new SpriteAnimation(characterView.SpriteAnimationConfig);
            characterSpriteAnimation.StartAnimation(characterView.SpriteRenderer, CharacterAnimationTracks.idle, characterView.AnimationLoop, characterView.AnimationSpeed);
            _spriteAnimations.Add(characterSpriteAnimation);
        }
    }

    public void Update(float deltaTime)
    {
        foreach(var spriteAnimation in _spriteAnimations)
        {
            spriteAnimation.Update();
        }
    }
}
