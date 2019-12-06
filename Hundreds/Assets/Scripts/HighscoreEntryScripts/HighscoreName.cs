using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

// Responsible for adding Characters to the inputted name
public class HighscoreName : MonoBehaviour
{
	public TextMeshProUGUI myName;
	public TextMeshProUGUI finalScoreText;
	public Button ConfirmButton;
	public Button BackspaceButton;
	public GameObject DatabaseManager;

	private int maxLength;
	private char[] word;
	private	int wordIndex;
	private int finalScore;

	/* List of Bad Words to be compared against
	 * Source: https://github.com/klhurley/ElementalEngine2/
	 * Licensed under license similiar to BSD
	 * https://github.com/klhurley/ElementalEngine2/issues/1
	 */
	private string[] BadWords = {
		"ASS", "FUC", "FUK", "FUQ", "FUX", "FCK", "COC", "COK", "COQ", "KOX",
		"KOC", "KOK", "KOQ", "CAC", "CAK", "CAQ", "KAC", "KAK", "KAQ", "DIC",
		"DIK", "DIQ", "DIX", "DCK", "PNS", "PSY", "FAG", "FGT", "NGR", "NIG",
		"CNT", "KNT", "SHT", "DSH", "TWT", "BCH", "CUM", "CLT", "KUM", "KLT",
		"SUC", "SUK", "SUQ", "SCK", "LIC", "LIK", "LIQ", "LCK", "JIZ", "JZZ",
		"GAY", "GEY", "GEI", "GAI", "VAG", "VGN", "SJV", "FAP", "PRN", "LOL",
		"JEW", "JOO", "GVR", "PUS", "PIS", "PSS", "SNM", "TIT", "FKU", "FCU",
		"FQU", "HOR", "SLT", "JAP", "WOP", "KIK", "KYK", "KYC", "KYQ", "DYK",
		"DYQ", "DYC", "KKK", "JYZ", "PRK", "PRC", "PRQ", "MIC", "MIK", "MIQ",
		"MYC", "MYK", "MYQ", "GUC", "GUK", "GUQ", "GIZ", "GZZ", "SEX", "SXX",
		"SXI", "SXE", "SXY", "XXX", "WAC", "WAK", "WAQ", "WCK", "POT", "THC",
		"VAJ", "VJN", "NUT", "STD", "LSD", "POO", "AZN", "PCP", "DMN", "ORL",
		"ANL", "ANS", "MUF", "MFF", "PHK", "PHC", "PHQ", "XTC", "TOK", "TOC",
		"TOQ", "MLF", "RAC", "RAK", "RAQ", "RCK", "SAC", "SAK", "SAQ", "PMS",
		"NAD", "NDZ", "NDS", "WTF", "SOL", "SOB", "FOB", "SFU"
	};

	void Start() {
		ResetName();
		finalScore = GameManager.GetFinalScore();

		finalScoreText.text = "Score: " + finalScore.ToString();

	}

	public void ResetName()
	{
		wordIndex = 0;
		maxLength = 3;
		word = new char[3]{'_', '_', '_'};
		myName.text = new string(word);

		BackspaceButton.interactable = false;
		ConfirmButton.interactable = false;
	}

	public void addCharacterToName(char i)
	{
		if (wordIndex == maxLength)
			return;

		word[wordIndex] = i;
		wordIndex++;
		myName.text = new string(word);

		if (isThreeLetterBadWord(new string(word))) {
			ResetName();
			return;
		}

		// Disable or enable Confirm depending upon position
		ConfirmButton.interactable = (wordIndex == 3);
		// Can always backspace when adding a character
		BackspaceButton.interactable = true;
	}

	public void Backspace () {
		if (wordIndex == 0)
			return;

		word[wordIndex-1] = '_';
		wordIndex--;

		BackspaceButton.interactable = (wordIndex != 0);
		ConfirmButton.interactable = (wordIndex == 3);
		myName.text = new string(word);
	}

	// Function to handle submission of the name
	public void SubmitName()
	{
		Debug.Log((myName.text) + " " +finalScore.ToString());
		DatabaseManager.GetComponent<DatabaseManager>().InsertEndless(new string(word), finalScore);
		GameManager.ResetGameLevel();
    	SceneManager.LoadScene("Main Menu");
	}

	// Determines if the specified Initials are considered to inapproprite
	private bool isThreeLetterBadWord(string Word)
	{
		if (Word.Length != 3)
			return false;
		return Array.Exists(BadWords, Element => Element == Word);
	}

}

