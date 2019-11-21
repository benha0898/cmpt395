using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighscoreName : MonoBehaviour
{
	string word = "";
	int wordIndex = 0;
	public TextMeshProUGUI myName;
	// Use this for initialization

	void Start() {
		myName.text = "_ _ _";
	}


	public void alphabetFunction (string Input)
	{
		wordIndex++;
		word = word + Input.ToString();
		myName.text = word;

	}
}

