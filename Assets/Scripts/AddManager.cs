using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddManager : MonoBehaviour, IUnityAdsListener
{
	[SerializeField] private bool testMode = true;
	
	public static AddManager Instance;

#if UNITY_IOS
	private string gameId = "4511168";
#elif UNITY_ANDROID
	private string gameId = "4511169";
#endif
	
	private GameOverHandler gameOverHandler;
	
	private void Awake() {
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else 
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
			
			Advertisement.AddListener(this);
			Advertisement.Initialize(gameId, testMode);
		}
	}
	
	public void ShowAd(GameOverHandler gameOverHandler)
	{
		this.gameOverHandler = gameOverHandler;
		
		Advertisement.Show("RewardedVideo");
	}

	public void OnUnityAdsDidError(string message)
	{
		Debug.Log($"Unity Ads Error : {message}");
	}

	public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
	{
		switch(showResult)
		{
			case ShowResult.Finished:
				gameOverHandler.ContinueGame();
				break;
			case ShowResult.Skipped:
				// Ad was skipped
				break;
			case ShowResult.Failed:
				Debug.Log("Ad Failed");
				break;
		}
	}

	public void OnUnityAdsDidStart(string placementId)
	{
		Debug.Log("As Started");
	}

	public void OnUnityAdsReady(string placementId)
	{
		Debug.Log("Unity Ads Ready");

	}

}
