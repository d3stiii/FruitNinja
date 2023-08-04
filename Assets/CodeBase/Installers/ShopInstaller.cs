using CodeBase.Services.Shop;
using CodeBase.Services.Shop.Skins;
using Zenject;

namespace CodeBase.Installers
{
    public class ShopInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSkinShopService();
        }

        private void BindSkinShopService() =>
            Container
                .Bind(typeof(IShopService<SkinShopItemDescription>))
                .To<SkinShopService>()
                .AsSingle();
    }
}