using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RewardAd : MonoBehaviour, IUnityAdsListener
{
   [SerializeField] private bool _testMode = true;
    [SerializeField] private Button _adsButton;

    private string _gameId = "4422426"; //��� game id

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
            _adsButton.interactable = true; //��������, ���� ������� ��������
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        //������ �������
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // ������ ��������� �������
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult) //��������� ������� (��� ����������� ��������������)
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
            //��������, ���� ������������ ��������� ������� �� �����
        }
        else if (showResult == ShowResult.Skipped)
        {
            //��������, ���� ������������ ��������� �������
        }
        else if (showResult == ShowResult.Failed)
        {
            //�������� ��� ������
        }
    }
}
