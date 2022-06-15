using UnityEngine;

public class BarrelFactory
{
    private PoolGameObject _barrelPool;

    public BarrelFactory(GameObject barrel)
    {
        _barrelPool = new PoolGameObject(barrel, "Barrel", "BarrelPool");
    }

    public BarrelView GetBarrel(Vector2 position, Quaternion rotation)
    {
        GameObject barrelGameObject = _barrelPool.Pop();
        barrelGameObject.transform.position = position;
        barrelGameObject.transform.rotation = rotation;
        BarrelView barrelView = barrelGameObject.GetComponent<BarrelView>();
        return barrelView;
    }

    public void Destroy(BarrelView barrel)
    {
        _barrelPool.Push(barrel.gameObject);
    }
}
