using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace Bomber
{
    public class AdsManager : MonoBehaviour
    {
        [SerializeField] private YandexGame _sdk;

        public void ShowAd()
        {
            _sdk._RewardedShow(1);
        }
    }
}
