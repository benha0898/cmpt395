using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Responsible for adding Characters to the inputted name
public class HighscoreName : MonoBehaviour
{
	private int maxLength;
	private char[] word;
	private	int wordIndex;

	public TextMeshProUGUI myName;

	void Start() {
		wordIndex = 0;
		maxLength = 3;
		word = new char[3]{'_', '_', '_'};

		myName.text = new string(word);
	}

	public void addCharacterToName(char i)
	{
		if (wordIndex == maxLength)
			return;

		word[wordIndex] = i;
		wordIndex++;
		myName.text = new string(word);
	}

}

