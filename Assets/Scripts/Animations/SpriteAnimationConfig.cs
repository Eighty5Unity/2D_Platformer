using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpriteAnimationConfig", menuName = "Config/SpriteAnimationConfig", order = 1)]
public class SpriteAnimationConfig : ScriptableObject
{
    [SerializeField] private List<SpriteSequence> _sequence;

    public List<SpriteSequence> Sequences => _sequence;
}
