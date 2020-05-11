//Property of Dylan Gleeson
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class flux_manager : MonoBehaviour
{
	#region Variables

	public static int current_flux = 0;
	public Text flux_text;


	#endregion


	#region Methods

	void Update()
	{

		flux_text.text = "= " + current_flux;

	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "flux")
		{
			current_flux += 1;
			Destroy(collision.gameObject);
		}


	}



	#endregion
}