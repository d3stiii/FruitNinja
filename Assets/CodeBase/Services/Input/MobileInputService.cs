using System.Linq;
using UnityEngine;

namespace CodeBase.Services.Input
{
    public class MobileInputService : IInputService
    {
        public bool SliceButtonDown() =>
            UnityEngine.Input.touches.Any(x => x.phase == TouchPhase.Began);

        public bool SliceButtonUp() =>
            UnityEngine.Input.touches.Any(x => x.phase == TouchPhase.Ended);

        public Vector3 GetTouchPosition() =>
            UnityEngine.Input.GetTouch(0).position;
    }
}