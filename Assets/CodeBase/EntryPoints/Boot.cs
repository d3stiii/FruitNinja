using UnityEngine;
using Zenject;

namespace CodeBase.EntryPoints
{
    public class Boot : MonoBehaviour
    {
        [Inject]
        public void Construct() { }
    }
}