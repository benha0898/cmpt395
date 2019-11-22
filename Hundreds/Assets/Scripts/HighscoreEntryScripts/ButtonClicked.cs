using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonClicked : MonoBehaviour
{
	Button btn;
	TextMeshProUGUI btnText;

    // Start is called before the first frame update
    void Start()
    {
		btn = GetComponent<Button>();
		btn.onClick.AddListener(clickedButton);

		btnText = btn.GetComponentInChildren<TextMeshProUGUI>();
    }

	// When the button is clicked, send the button's character to the initials
	// for it to be added
	void clickedButton()
	{
		// Get the Character from the Button Text
		char t = btnText.text.ToCharArray()[0];

		HighscoreName hsScript = GameObject.Find("HighscoreCanvas")
			.GetComponent<HighscoreName>();

		hsScript.addCharacterToName(t);
	}

}
