using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] private Image _currentCharacterImage;
    [SerializeField] private Sprite[] _characterImages;

    public Image CurrentCharacterImage { get => _currentCharacterImage; set => _currentCharacterImage = value; }
    public Sprite[] CharacterImages => _characterImages;
}
