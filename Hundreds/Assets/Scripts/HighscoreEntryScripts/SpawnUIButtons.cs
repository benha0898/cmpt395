using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SpawnUIButtons : MonoBehaviour
{
	public GameObject ButtonPrefab;
	public Canvas keyboard;

	private RectTransform kbtrans;
	char currentChar;

	/* Spawn Keyboard text within the Designated Keyboard Canvas
	 *
	 */
    void Start()
    {
		kbtrans = keyboard.GetComponent<RectTransform>();
		currentChar = 'A';

		float offset = (kbtrans.rect.height/2) / 3;

		createButtonRow(10, 0);
		createButtonRow(10, offset);
		createButtonRow(6, offset * 2);

    }

	void createButtonRow(int n, float Height) {
		float kb_width = kbtrans.rect.width / 10;
		float offset = kb_width/2;

		offset += (kb_width * (10-n))/2;


		for (int i = 0; i < n; i++) {
			// Initialize at the Bottom Left of the parent
			// Canvas
			Vector3 Position = new Vector3(
					kbtrans.transform.position.x - (kbtrans.rect.width/2),
					kbtrans.transform.position.y - Height,
					0);

			GameObject c = Instantiate(ButtonPrefab, Position,
					Quaternion.identity) as GameObject;
			c.transform.SetParent(kbtrans.transform);

			// Calculations for Offsets
			c.transform.position += new Vector3(offset + kb_width * i, 0,0);


			setButtonText(c);

		}
	}

	void setButtonText(GameObject c) {
			c.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>()
				.text = (currentChar.ToString());
			currentChar++;
	}




}
