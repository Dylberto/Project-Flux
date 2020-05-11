//Property of Dylan Gleeson
using System;
using System.Collections;
using UnityEngine;


public class player_animations2D : MonoBehaviour
{
    #region Variables

    private float move_input;
    private Animator anim;
    public Transform ground_check;
    private bool is_grounded;
    public LayerMask what_is_ground;
    public float ground_check_radius;
    private GameObject player;


    #endregion


    #region Methods
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        #region Running

        move_input = Input.GetAxisRaw("Horizontal");

        if (move_input == 0)
        {
            anim.SetBool("is_running", false);
        }
        else
        {
            anim.SetBool("is_running", true);
        }

        #endregion


        #region Jumping

        is_grounded = Physics2D.OverlapCircle(ground_check.position, ground_check_radius, what_is_ground);

        if (Input.GetKeyDown(KeyCode.Space) && is_grounded == true)
        {

            anim.SetBool("is_jumping", true);
           

        }
        if(is_grounded == true)
        {
            anim.SetBool("is_jumping", false);
        }
        else
        {
            anim.SetBool("is_jumping", true);
        }

    

		#endregion


		#region Dashing


       if(player.GetComponent<player_controller2D>().dashed == true)
        {
            anim.SetBool("dashed", true);
        }
        else
        {
            anim.SetBool("dashed", false);
        }


		#endregion

		#region Hit

       if(player.GetComponent<player_controller2D>().hit == true)
        {
            anim.SetBool("hit", true);
        }
        else
        {
            anim.SetBool("hit", false);
        }

		#endregion

	}


	#endregion



}