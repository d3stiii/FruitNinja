using CodeBase.Services.Shop;
using Zenject;

namespace CodeBase.Installers
{
    public class ShopInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindShopService();
        }

        private void BindShopService() =>
            Container
                .Bind<IShopService>()
                .To<ShopService>()
                .AsSingle();
    }
}