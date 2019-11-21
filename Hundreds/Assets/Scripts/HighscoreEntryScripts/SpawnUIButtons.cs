using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUIButtons : MonoBehaviour
{
	public GameObject ButtonPrefab;
	public Canvas keyboard;

	/* Spawn Keyboard text within the Designated Keyboard Canvas
	 *
	 */
    void Start()
    {
		RectTransform kbtrans = keyboard.GetComponent<RectTransform>();

		float kb_width = kbtrans.rect.width / 9;
		float kb_height = kbtrans.rect.height / 3;

		float offset = kb_width/2;

		for (int i = 0; i < 10; i++) {
			// Initialize at the Bottom Left of the parent
			// Canvas
			Vector3 Position = new Vector3(
					kbtrans.transform.position.x - (kbtrans.rect.width/2),
					kbtrans.transform.position.y,
					0);

			GameObject c = Instantiate(ButtonPrefab, Position,
					Quaternion.identity) as GameObject;
			c.transform.SetParent(kbtrans.transform);

			// Calculations for Offsets
			c.transform.position += new Vector3(offset + kb_width * i, 0,0);


		}

    }




}
