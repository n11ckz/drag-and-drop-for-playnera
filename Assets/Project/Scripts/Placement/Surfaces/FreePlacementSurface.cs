using UnityEngine;

namespace Project
{
    public class FreePlacementSurface : BasePlacementSurface
    {
        protected override void Process(Collider2D collider)
        {
            if (!collider.TryGetComponentInParent(out IPlaceable placeable))
                return;

            placeable.Place();
        }
    }
}
