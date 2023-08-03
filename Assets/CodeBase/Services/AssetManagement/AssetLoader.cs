using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Services.AssetManagement
{
    public interface IAssetLoader
    {
        TAsset LoadAsset<TAsset>(string path) where TAsset : Object;
        TAsset[] LoadAllAssets<TAsset>(string path) where TAsset : Object;
    }

    public class AssetLoader : IAssetLoader
    {
        public TAsset LoadAsset<TAsset>(string path) where TAsset : Object
        {
            var asset = Resources.Load<TAsset>(path);

            if (asset == null)
                throw new ArgumentException("Provided asset path is not correct");

            return asset;
        }

        public TAsset[] LoadAllAssets<TAsset>(string path) where TAsset : Object
        {
            var assets = Resources.LoadAll<TAsset>(path);

            if (assets == null || assets.Length == 0)
                throw new ArgumentException("Provided asset path is not correct");

            return assets;
        }
    }
}