using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpriteSequence
{
    public CharacterAnimationTracks AnimationTrack;
    public List<Sprite> Sprites = new List<Sprite>();
}
