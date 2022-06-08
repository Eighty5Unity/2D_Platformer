using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : IDisposable
{
    private SpriteAnimationConfig _config;
    private Dictionary<SpriteRenderer, CharacterAnimation> _activeAnimation = new Dictionary<SpriteRenderer, CharacterAnimation>();

    public SpriteAnimation(SpriteAnimationConfig config)
    {
        _config = config;
    }

    public void StartAnimation(SpriteRenderer spriteRenderer, CharacterAnimationTracks track, bool loop, float speed)
    {
        if(_activeAnimation.TryGetValue(spriteRenderer, out var animation))
        {
            animation.Loop = loop;
            animation.Speed = speed;
            animation.Sleeps = false;
            if(animation.Track != track)
            {
                animation.Track = track;
                animation.Sprites = _config.Sequences.Find(sequence => sequence.AnimationTrack == track).Sprites;
                animation.Counter = 0;
            }
        }
        else
        {
            _activeAnimation.Add(spriteRenderer, new CharacterAnimation()
            {
                Track = track,
                Sprites = _config.Sequences.Find(sequence => sequence.AnimationTrack == track).Sprites,
                Loop = loop,
                Speed = speed
            });
        }
    }

    public void StopAnimation(SpriteRenderer sprite)
    {
        if (_activeAnimation.ContainsKey(sprite))
        {
            _activeAnimation.Remove(sprite);
        }
    }

    public void Update()
    {
        foreach(var animation in _activeAnimation)
        {
            animation.Value.Update();
            animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
        }
    }

    public void Dispose()
    {
        _activeAnimation.Clear();
    }
}
