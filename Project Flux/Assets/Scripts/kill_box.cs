//Property of Dylan Gleeson
using System;
using System.Collections;
using UnityEngine;

public class kill_box : MonoBehaviour
{
    #region Variables

    private GameObject player;
    public float shake_time;
    public float shake_amp;
    public float shake_frequency;

    

	#endregion


	#region Methods
	void Start()
    {
        
       player = GameObject.FindGameObjectWithTag("Player");
        
        
    }

  


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy" && player.GetComponent<player_controller2D>().dashed == true)
        {
            
            Destroy(collision.gameObject);

        }
    }

   

    #endregion
}