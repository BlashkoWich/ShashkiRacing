using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RewardAd : MonoBehaviour, IUnityAdsListener
{
   [SerializeField] private bool _testMode = true;
    [SerializeField] private Button _adsButton;

    private string _gameId = "4422426"; //ваш game id

    private string _rewardedVideo = "Rewarded_Android";

    private int coins;
    void Start()
    {
        _adsButton = GetComponent<Button>();
        _adsButton.interactable = Advertisement.IsReady(_rewardedVideo);

        if (_adsButton)
            _adsButton.onClick.AddListener(ShowRewardedVideo);

        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, true);
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(_rewardedVideo);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _rewardedVideo)
        {
            _adsButton.interactable = true; //действия, если реклама доступна
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        //ошибка рекламы
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // только запустили рекламу
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) //обработка рекламы (тут определеяем вознаграждение)
    {
        if (showResult == ShowResult.Finished)
        {
            if (placementId == "Rewarded_Android")
            {
                if (PlayerPrefs.HasKey("Coin"))
                {
                    coins = PlayerPrefs.GetInt("Coin");
                    coins += 50;
                    PlayerPrefs.SetInt("Coin", coins);
                }
            }
            //действия, если пользователь посмотрел рекламу до конца
        }
        else if (showResult == ShowResult.Skipped)
        {
            //действия, если пользователь пропустил рекламу
        }
        else if (showResult == ShowResult.Failed)
        {
            //действия при ошибке
        }
    }
}
