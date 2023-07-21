using System.Collections;
using UnityEngine;

namespace CodeBase.Utilities
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
        void StopCoroutine(IEnumerator coroutine);
    }

    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner { }
}