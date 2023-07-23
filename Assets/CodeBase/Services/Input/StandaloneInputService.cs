using UnityEngine;

namespace CodeBase.Services.Input
{
    public class StandaloneInputService : IInputService
    {
        public bool SliceButtonDown() =>
            UnityEngine.Input.GetMouseButtonDown(0);

        public bool SliceButtonUp() =>
            UnityEngine.Input.GetMouseButtonUp(0);

        public Vector3 GetTouchPosition() =>
            UnityEngine.Input.mousePosition;
    }
}