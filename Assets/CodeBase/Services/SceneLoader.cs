using System;
using System.Collections;
using CodeBase.Utilities;
using UnityEngine.SceneManagement;

namespace CodeBase.Services
{
    public interface ISceneLoader
    {
        void LoadScene(string name, Action onLoaded = null);
    }

    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) => 
            _coroutineRunner = coroutineRunner;

        public void LoadScene(string name, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(Load(name, onLoaded));

        private IEnumerator Load(string name, Action onLoaded)
        {
            if (IsAlreadyLoaded(name))
            {
                onLoaded?.Invoke();
                yield break;
            }

            var sceneLoad = SceneManager.LoadSceneAsync(name);

            while (!sceneLoad.isDone)
                yield return null;

            onLoaded?.Invoke();
        }

        private static bool IsAlreadyLoaded(string name) =>
            SceneManager.GetActiveScene().name == name;
    }
}