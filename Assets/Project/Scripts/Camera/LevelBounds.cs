using UnityEngine;

namespace Project
{
    public class LevelBounds : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _background;

        public (float min, float max) GetMinAndMaxBoundsOnX()
        {
            Bounds bounds = _background.bounds;
            return (bounds.min.x, bounds.max.x);
        }
    }
}
