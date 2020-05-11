//Property of Dylan Gleeson
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class new_scene : MonoBehaviour
{
	#region Variables



	#endregion


	#region Methods
	

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("Level 1");
    }


    #endregion
}