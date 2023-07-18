using System.Collections;
using UnityEngine;

namespace CodeBase.Utilities
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }

    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner { }
}