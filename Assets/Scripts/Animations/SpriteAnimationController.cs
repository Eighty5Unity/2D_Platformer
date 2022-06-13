using System.Collections.Generic;

public class SpriteAnimationController : IUpdate
{
    private List<SpriteAnimation> _spriteAnimations = new List<SpriteAnimation>();

    public List<SpriteAnimation> SpriteAnimations => _spriteAnimations;

    public SpriteAnimationController(CharacterView[] characterViews)
    {
        foreach(var characterView in characterViews)
        {
            var characterSpriteAnimation = characterView.SpriteAnimation;
            characterSpriteAnimation.StartAnimation(characterView.SpriteRenderer, CharacterAnimationTracks.idle, characterView.AnimationIdleLoop, characterView.AnimationIdleSpeed);
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
