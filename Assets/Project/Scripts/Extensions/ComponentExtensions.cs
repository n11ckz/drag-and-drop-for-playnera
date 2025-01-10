using UnityEngine;

namespace Project
{
    public static class ComponentExtensions
    {
        public static bool TryGetComponentInParent<T>(this Component component, out T result)
        {
            result = component.GetComponentInParent<T>();
            return result != null;
        }
    }
}
