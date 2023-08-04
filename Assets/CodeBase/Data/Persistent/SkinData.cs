using System;
using System.Collections.Generic;

namespace CodeBase.Data.Persistent
{
    [Serializable]
    public class SkinData
    {
        public List<string> OwnedSkinIds = new();
        public string SelectedSkinId;

        public SkinData(string defaultSkin)
        {
            AddSkin(defaultSkin);
            SelectedSkinId = defaultSkin;
        }

        public void AddSkin(string id)
        {
            if (OwnedSkinIds.Contains(id))
                return;

            OwnedSkinIds.Add(id);
        }
    }
}