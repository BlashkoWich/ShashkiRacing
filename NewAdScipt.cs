using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;



public class NewAdScipt : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool _testMode = true;

    private string _gameId = "4422426"; //��� game id

    private string _video = "Interstitial_Android";
    private string _rewardedVideo = "Rewarded_Android";
    private string _banner = "Banner_Android";

    private int coins;

    void Start() // ������������� ��������
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_gameId, _testMode);

        #region Banner

        StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);

        #endregion
    }

    public static void ShowAdsVideo(string placementId) //������������� ������� �� ����
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("Advertisement not ready!");
        }
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(_banner);
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId == _rewardedVideo)
        {
            //��������, ���� ������� ��������
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
            if (PlayerPrefs.HasKey("Coin")) coins = PlayerPrefs.GetInt("Coin");
            coins += 50;
            PlayerPrefs.SetInt("Coin", coins);
            //��������, ���� ������������ ��������� ������� �� �����
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("������");
            //��������, ���� ������������ ��������� ������� + ������
        }
        else if (showResult == ShowResult.Failed)
        {
            //�������� ��� ������
        }
    }

}