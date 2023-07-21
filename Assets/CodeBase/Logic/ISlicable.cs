using UnityEngine;

namespace CodeBase.Logic
{
    public interface ISlicable
    {
        void Slice(Vector3 direction, Vector3 position, float sliceForce);
    }
}