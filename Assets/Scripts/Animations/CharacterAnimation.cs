using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation
{
    public CharacterAnimationTracks Track;
    public List<Sprite> Sprites;
    public bool Loop = false;
    public float Speed = 10f;
    public float Counter = 0f;
    public bool Sleeps;

    public void Update()
    {
        if (Sleeps)
        {
            return;
        }

        Counter += Time.deltaTime * Speed;
        if (Loop)
        {
            while(Counter > Sprites.Count)
            {
                Counter -= Sprites.Count;
            }
        }
        else if(Counter > Sprites.Count)
        {
            Counter = Sprites.Count - 1;
            Sleeps = true;
        }
    }
}
