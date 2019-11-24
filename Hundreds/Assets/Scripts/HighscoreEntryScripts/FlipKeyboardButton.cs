using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlipKeyboardButton : MonoBehaviour
{
	public Canvas flip;

	public void FlipButton()
	{
		flip.transform.Rotate(new Vector3(180f, 180f, 0f));
	}


}
