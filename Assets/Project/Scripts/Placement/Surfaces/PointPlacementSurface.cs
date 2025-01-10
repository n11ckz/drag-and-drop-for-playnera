using System.Collections;
using UnityEngine;

namespace Project
{
    public class PointPlacementSurface : BasePlacementSurface
    {
        [SerializeField] private Transform _point;
        [SerializeField, Range(0.0f, 0.25f)] private float _duration;

        protected override void Process(Collider2D collider)
        {
            if (!collider.TryGetComponentInParent(out IPlaceable placeable))
                return;

            placeable.Place();
            StartCoroutine(MoveToPoint(placeable.Transform));
        }

        // можно было использовать какой-нибудь твин-ассет, но подумал, что будет лишным тянуть его, ради одной анимации
        private IEnumerator MoveToPoint(Transform item)
        {
            Vector2 startPosition = item.position;
            float elapsedTime = 0.0f;

            while (elapsedTime < _duration)
            {
                elapsedTime += Time.deltaTime;

                float t = Mathf.Clamp01(elapsedTime / _duration);
                item.position = Vector3.Lerp(startPosition, _point.position, t);

                yield return null;
            }
        }
    }
}
