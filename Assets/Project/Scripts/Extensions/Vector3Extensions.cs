using UnityEngine;

namespace Project
{
    public static class Vector3Extensions
    {
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
            new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
    }
}
