using UnityEngine;

public interface IPoolGameObject
{
    GameObject Pop();
    void Push(GameObject gameObject);
}
