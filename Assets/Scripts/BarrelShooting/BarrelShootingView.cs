using UnityEngine;

public class BarrelShootingView : MonoBehaviour
{
    //[Header("ShootingSettings")]
    //[SerializeField] [Range(-0.05f, 0.05f)] private float _leftRight;
    //[SerializeField] [Range(0.03f, 0.09f)] private float _downUp;

    public Transform BarrelShootPoint => transform;
    //public float LeftRight => _leftRight;
    //public float DownUp => _downUp;
    public float LeftRight => Random.Range(0.006f, 0.025f);
    public float DownUp => Random.Range(0.04f, 0.08f);
}
