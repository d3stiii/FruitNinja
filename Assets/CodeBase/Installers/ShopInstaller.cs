using CodeBase.Services.Shop;
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
                .Bind<ISkinShopService>()
                .To<SkinShopService>()
                .AsSingle();
    }
}