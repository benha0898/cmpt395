using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonClicked : MonoBehaviour
{
	Button btn;

    // Start is called before the first frame update
    void Start()
    {
		btn = GetComponent<Button>();
		btn.onClick.AddListener(clickedButton);
    }

	void clickedButton() {
		string t = (btn.GetComponentInChildren<TextMeshProUGUI>()
				.text);
		GameObject highScore = GameObject.Find("HighscoreCanvas");

		Debug.Log(highScore);

		highScore.GetComponent<HighscoreName>().alphabetFunction(t);

	}

}
