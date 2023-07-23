using UnityEngine;

namespace CodeBase.Services.Input
{
    public interface IInputService
    {
        bool SliceButtonDown();
        bool SliceButtonUp();
        Vector3 GetTouchPosition();
    }
}