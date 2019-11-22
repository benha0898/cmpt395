using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SpawnUIButtons : MonoBehaviour
{
	public GameObject ButtonPrefab;
	public Canvas keyboard;
	public int ButtonsPerRow;

	private RectTransform kbtrans;
	private char currentChar;
	// Upper Lefthand Coordinates of the Canvas. Shall be used as the reference
	private Vector2 CanvasOrigin;
	// Move the Rows of buttons down a static amount
	private float horzStaticOffset;
	// Spacing between Buttons for each row
	private float kb_width;

	/* Spawn Keyboard text within the Designated Keyboard Canvas */
    void Start()
    {
		kbtrans = keyboard.GetComponent<RectTransform>();
		kb_width = kbtrans.rect.width / ButtonsPerRow;

		// Compute the Upper Lefthand Corner Vector
		CanvasOrigin = new Vector2(
					kbtrans.transform.position.x - (kbtrans.rect.width/2),
					kbtrans.transform.position.y + (kbtrans.rect.height/2)
				);

		// Number of rows + 1 for an offset
		float horzOffset = ((kbtrans.rect.height) / 3);
		// Static Offset to move all the Rows down by
		horzStaticOffset = horzOffset/2;

		currentChar = 'A';
		createButtonRow(10, horzOffset*0);
		createButtonRow(10, horzOffset*1);
		createButtonRow(6, horzOffset * 2);
    }

	// Create a row of n buttons, which shall be created at the given Height
	void createButtonRow(int n, float Height)
	{
		float leftOverSpacing = kb_width * (ButtonsPerRow - n);
		float vertOffset = (leftOverSpacing + kb_width) / 2;

		for (int i = 0; i < n; i++) {
			Vector3 Position = new Vector3(
					CanvasOrigin.x,
					CanvasOrigin.y - Height - horzStaticOffset,
					0);
			GameObject c = Instantiate(ButtonPrefab, Position,
					Quaternion.identity) as GameObject;

			c.transform.SetParent(kbtrans.transform);

			// Calculations for Offsets
			c.transform.position += new Vector3(vertOffset + kb_width * i, 0,0);
			setButtonText(c, currentChar.ToString());
			currentChar++;
		}
	}

	// Helper function to obtain the set the Text on a Button Object
	void setButtonText(GameObject c, string t)
	{
			Button button = c.GetComponent<Button>();
			button.GetComponentInChildren<TextMeshProUGUI>()
				.text = (t);
	}
}
