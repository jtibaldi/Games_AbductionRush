using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRanking : MonoBehaviour {

	// Use this for initialization
	void Start () {                      
    }

    // Update is called once per frame
    public void UpdateRanking () {
		Transform RankingOneNameTransform = transform.Find("RankingOneName");
		Transform RankingOneScoreTransform = transform.Find("RankingOneScore");
		Transform RankingTwoNameTransform = transform.Find("RankingTwoName");
		Transform RankingTwoScoreTransform = transform.Find("RankingTwoScore");
		Transform RankingThreeNameTransform = transform.Find("RankingThreeName");
		Transform RankingThreeScoreTransform = transform.Find("RankingThreeScore");
		Transform RankingFourNameTransform = transform.Find("RankingFourName");
		Transform RankingFourScoreTransform = transform.Find("RankingFourScore");
		Transform RankingFiveNameTransform = transform.Find("RankingFiveName");
		Transform RankingFiveScoreTransform = transform.Find("RankingFiveScore");
		Transform RankingSixNameTransform = transform.Find("RankingSixName");
		Transform RankingSixScoreTransform = transform.Find("RankingSixScore");
		Transform RankingSevenNameTransform = transform.Find("RankingSevenName");
		Transform RankingSevenScoreTransform = transform.Find("RankingSevenScore");
		Transform RankingEightNameTransform = transform.Find("RankingEightName");
		Transform RankingEightScoreTransform = transform.Find("RankingEightScore");
		Transform RankingNineNameTransform = transform.Find("RankingNineName");
		Transform RankingNineScoreTransform = transform.Find("RankingNineScore");
		Transform RankingTenNameTransform = transform.Find("RankingTenName");
		Transform RankingTenScoreTransform = transform.Find("RankingTenScore");
		Text RankingOneName = RankingOneNameTransform.GetComponent<Text>();
		Text RankingOneScore = RankingOneScoreTransform.GetComponent<Text>();
		Text RankingTwoName = RankingTwoNameTransform.GetComponent<Text>();
		Text RankingTwoScore = RankingTwoScoreTransform.GetComponent<Text>();
		Text RankingThreeName = RankingThreeNameTransform.GetComponent<Text>();
		Text RankingThreeScore = RankingThreeScoreTransform.GetComponent<Text>();
		Text RankingFourName = RankingFourNameTransform.GetComponent<Text>();
		Text RankingFourScore = RankingFourScoreTransform.GetComponent<Text>();
		Text RankingFiveName = RankingFiveNameTransform.GetComponent<Text>();
		Text RankingFiveScore = RankingFiveScoreTransform.GetComponent<Text>();
		Text RankingSixName = RankingSixNameTransform.GetComponent<Text>();
		Text RankingSixScore = RankingSixScoreTransform.GetComponent<Text>();
		Text RankingSevenName = RankingSevenNameTransform.GetComponent<Text>();
		Text RankingSevenScore = RankingSevenScoreTransform.GetComponent<Text>();
		Text RankingEightName = RankingEightNameTransform.GetComponent<Text>();
		Text RankingEightScore = RankingEightScoreTransform.GetComponent<Text>();
		Text RankingNineName = RankingNineNameTransform.GetComponent<Text>();
		Text RankingNineScore = RankingNineScoreTransform.GetComponent<Text>();
		Text RankingTenName = RankingTenNameTransform.GetComponent<Text>();
		Text RankingTenScore = RankingTenScoreTransform.GetComponent<Text>();

		RankingOneName.text = PlayerPrefs.GetString("RankingOneName");
		RankingOneScore.text = PlayerPrefs.GetInt("RankingOneScore").ToString();
		RankingTwoName.text = PlayerPrefs.GetString("RankingTwoName");
		RankingTwoScore.text = PlayerPrefs.GetInt("RankingTwoScore").ToString();
		RankingThreeName.text = PlayerPrefs.GetString("RankingThreeName");
		RankingThreeScore.text = PlayerPrefs.GetInt("RankingThreeScore").ToString();
		RankingFourName.text = PlayerPrefs.GetString("RankingFourName");
		RankingFourScore.text = PlayerPrefs.GetInt("RankingFourScore").ToString();
		RankingFiveName.text = PlayerPrefs.GetString("RankingFiveName");
		RankingFiveScore.text = PlayerPrefs.GetInt("RankingFiveScore").ToString();
		RankingSixName.text = PlayerPrefs.GetString("RankingSixName");
		RankingSixScore.text = PlayerPrefs.GetInt("RankingSixScore").ToString();
		RankingSevenName.text = PlayerPrefs.GetString("RankingSevenName");
		RankingSevenScore.text = PlayerPrefs.GetInt("RankingSevenScore").ToString();
		RankingEightName.text = PlayerPrefs.GetString("RankingEightName");
		RankingEightScore.text = PlayerPrefs.GetInt("RankingEightScore").ToString();
		RankingNineName.text = PlayerPrefs.GetString("RankingNineName");
		RankingNineScore.text = PlayerPrefs.GetInt("RankingNineScore").ToString();
		RankingTenName.text = PlayerPrefs.GetString("RankingTenName");
		RankingTenScore.text = PlayerPrefs.GetInt("RankingTenScore").ToString();
	}
}
