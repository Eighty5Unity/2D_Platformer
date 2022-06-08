using UnityEngine;

public class WellView : MonoBehaviour
{
    [SerializeField] private Transform _muzzleTransform;

    public Transform MuzzleTransform => _muzzleTransform;
}
