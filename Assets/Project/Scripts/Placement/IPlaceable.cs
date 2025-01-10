using UnityEngine;

namespace Project
{
    public interface IPlaceable
    {
        public Transform Transform { get; }

        public void Place();
    }
}
