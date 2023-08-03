using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class BladeShopItem : MonoBehaviour
    {
        [SerializeField] private Button _purchaseButton;
        
        private void Awake()
        {
            _purchaseButton.onClick.AddListener(Purchase);
        }

        private void Purchase() { }
    }
}