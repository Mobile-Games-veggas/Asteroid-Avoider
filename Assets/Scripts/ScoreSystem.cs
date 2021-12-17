using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
	[SerializeField] private TMP_Text scoreText;
	[SerializeField] private float scoreMultiplayer;
	
	private float score;
	private bool shoudCount = true;
	
	void Update()
	{
		if (!shoudCount) { return; }
		
		score += Time.deltaTime * scoreMultiplayer;
		
		scoreText.text = Mathf.FloorToInt(score).ToString();
	}
	
	public int EndTimer()
	{
		shoudCount = false;
		
		scoreText.text = string.Empty;
		
		return Mathf.FloorToInt(score);
	}
}
