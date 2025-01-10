using UnityEngine;

namespace Project
{
    [SelectionBase, RequireComponent(typeof(Rigidbody2D))]
    public class BasicItem : MonoBehaviour, IDragListener, IBeginDragListener, IEndDragListener, IPlaceable
    {
        private const int DefaultGravity = 1;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _draggableCollider;
        [SerializeField] private Collider2D _placementCollider;

        public Transform Transform => transform;

        public void OnBeginDrag()
        {
            _rigidbody.gravityScale = 0;
            _draggableCollider.enabled = false;
            _placementCollider.enabled = false;
        }

        public void OnEndDrag()
        {
            _rigidbody.gravityScale = DefaultGravity;
            _placementCollider.enabled = true;
        }

        public void Place()
        {
            _rigidbody.gravityScale = 0;
            _rigidbody.velocity = Vector2.zero;
            _draggableCollider.enabled = true;
            _placementCollider.enabled = false;
        }
    }
}
