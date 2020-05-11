//Property of Dylan Gleeson
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shop : MonoBehaviour
{
    #region Variables

    private GameObject player;

    public GameObject jump_panel;
    public GameObject health_panel;
    public GameObject control_panel;
    public GameObject shop_ui;


    public int jump_price;
    public int health_price;

    public Text jump_price_text;
    public Text health_price_text;




	#endregion


	#region Methods
	void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        jump_panel.SetActive(false);
        health_panel.SetActive(false);
        control_panel.SetActive(false);
    }

     void Update()
    {
       if(health_managment.health_max > 5)
        {
            health_panel.SetActive(true);
        }

        jump_price_text.text = jump_price + "";

        health_price_text.text = health_price + "";

 
    }


    public void more_health()
    {
        if (health_managment.health_max < 5 && flux_manager.current_flux > health_price)
        {
            health_managment.health_max += 1;

            flux_manager.current_flux -= health_price;

        }
        if(health_managment.health_max >= 5)
        {
            health_panel.SetActive(true);
        }

    }


    public void extra_jump()
    {
        if(flux_manager.current_flux > jump_price)
        {
            flux_manager.current_flux -= jump_price;
            player_controller2D.extra_jump = 1;
            jump_panel.SetActive(true);
        }
           
    }


    public void load_level()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void exit()
    {
        Application.Quit();
    }

    public void controls()
    {
        control_panel.SetActive(true);
        shop_ui.SetActive(false);

    }

    public void no_controls()
    {
        control_panel.SetActive(false);
        shop_ui.SetActive(true);
    }



    #endregion
}