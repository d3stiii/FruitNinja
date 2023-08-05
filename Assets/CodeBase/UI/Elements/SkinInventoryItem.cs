using CodeBase.Services.Skins;
using CodeBase.StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class SkinInventoryItem : MonoBehaviour
    {
        [SerializeField] private Button _equipButton;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Image _icon;
        private SkinData _skinData;
        private ISkinsService _skinsService;

        public void Construct(SkinData skinData, ISkinsService skinsService)
        {
            _skinsService = skinsService;
            _skinData = skinData;
        }

        public void Initialize()
        {
            _nameText.text = _skinData.Name;
            _icon.sprite = _skinData.Icon;
            _equipButton.gameObject.SetActive(_skinsService.GetEquippedSkin() != _skinData);
            _equipButton.onClick.AddListener(Equip);
        }

        private void Equip() =>
            _skinsService.Equip(_skinData);
    }
}