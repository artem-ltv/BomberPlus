using UnityEngine;
using YG;

namespace Bomber
{
    public class AdsManager : MonoBehaviour
    {
        [SerializeField] private YandexGame _sdk;
        [SerializeField] private LosePanel _losePanel;

        public void ShowAd()
        {
            _sdk._RewardedShow(1);
        }

        public void OnShowAd()
        {
            _losePanel.EnableContinueButton();
        }
    }
}
