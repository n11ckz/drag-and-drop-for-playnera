using UnityEngine;

namespace Project
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public abstract class BasePlacementSurface : MonoBehaviour
    {
        private void Awake() =>
            GetComponent<PolygonCollider2D>().isTrigger = true;

        private void OnTriggerEnter2D(Collider2D collider) =>
            Process(collider);

        protected abstract void Process(Collider2D collider);
    }
}
