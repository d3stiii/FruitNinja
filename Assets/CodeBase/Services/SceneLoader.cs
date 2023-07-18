using System;
using UnityEngine.SceneManagement;

namespace CodeBase.Services
{
    public interface ISceneLoader
    {
        void LoadScene(string name, Action onLoaded = null);
    }

    public class SceneLoader : ISceneLoader
    {
        public void LoadScene(string name, Action onLoaded = null)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(name);

            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
                onLoaded?.Invoke();
            }
        }
    }
}