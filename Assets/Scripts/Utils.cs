using UnityEngine;

public static class Utils
{
    public static Vector3 Change(this Vector3 org, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? org.x, y ?? org.y, z ?? org.z);
    }
}
