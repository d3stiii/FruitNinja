using CodeBase.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.EntryPoints
{
    public class Boot : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;

        private void Awake()
        {
            _sceneLoader.LoadScene("Main");
        }

        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
    }
}