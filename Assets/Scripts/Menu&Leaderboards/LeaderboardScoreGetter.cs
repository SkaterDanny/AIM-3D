﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LeaderboardScoreGetter : MonoBehaviour {

    //Script for putting the score from online database on screen

	//Made By Danny Kruiswijk
	
	private Text nameBoard;
	private Text scoreBoard;
	private GameObject nameObject;
	private GameObject scoreObject;
	private PhpSender sender;
    //Make new list of scores
	private List<string> scorelist = new List<string>();
    //Empty String
	private string displayName = "";
	private string displayScore = "";
	
	void Awake () {
		sender = GameObject.Find ("Nameholder").GetComponent<PhpSender>();
		nameObject = GameObject.Find ("NameText");
		scoreObject = GameObject.Find ("ScoreText");
		nameBoard = nameObject.GetComponent<Text>();
		scoreBoard = scoreObject.GetComponent<Text>();

		//Gets the score from PHP
		scorelist = sender.getCurrentScoreList;

		//Puts the score on screen
		foreach (string score in scorelist) {
			string[] lijn = score.Split(',');
			displayName += lijn[0].ToString() + "\n";
			displayScore += lijn[1].ToString() + "\n";
		}
		nameBoard.text = displayName;
		scoreBoard.text = displayScore;
	}
}