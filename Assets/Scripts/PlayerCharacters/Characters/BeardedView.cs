using UnityEngine;

public class BeardedView : MonoBehaviour, ICharacters
{
    public CharactersEnum Character => CharactersEnum.Bearded;
}