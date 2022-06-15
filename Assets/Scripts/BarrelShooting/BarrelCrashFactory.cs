using UnityEngine;

public class BarrelCrashFactory
{
    private PoolGameObject _barrelCrashPool;

    public BarrelCrashFactory(GameObject barrelCrashEffect)
    {
        _barrelCrashPool = new PoolGameObject(barrelCrashEffect, "BarrelCrashEffect", "BarrelCrashEffectPool");
    }

    public ParticleSystem GetBarrelCrashEffect(Vector3 position, Quaternion rotation)
    {
        GameObject barrelCrashEffectGO = _barrelCrashPool.Pop();
        barrelCrashEffectGO.transform.position = position;
        barrelCrashEffectGO.transform.rotation = rotation;
        ParticleSystem barrelCrashParticleSysytem = barrelCrashEffectGO.GetComponent<ParticleSystem>();
        return barrelCrashParticleSysytem;
    }

    public void Destroy(ParticleSystem barrelCrashEffect)
    {
        _barrelCrashPool.Push(barrelCrashEffect.gameObject);
    }
}
