//Property of Dylan Gleeson
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class enemy_platform : MonoBehaviour
{
    #region Variables

    public float spd;
    public bool moving_right = true;
    public Transform ground_check;
    public Transform wall_check;
    public float knockback_force;
    private Transform player;
 
   
    #endregion


    #region Methods

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.Translate(Vector2.right * spd * Time.deltaTime);

        RaycastHit2D ground_hit = Physics2D.Raycast(ground_check.position, Vector2.down, 0.2f);
        RaycastHit2D wall_hit = Physics2D.Raycast(wall_check.position, Vector2.right, 0.5f);

        if (ground_hit.collider == false)
        {
            if (moving_right == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moving_right = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moving_right = true;
            }
        }

        if(wall_hit.collider == true && wall_hit.collider.tag == "ground")
        {
            if (moving_right == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moving_right = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moving_right = true;
            }
        }

        if (wall_hit.collider == true && wall_hit.collider.tag == "Player")
        {
            if (moving_right == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moving_right = false;
              
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moving_right = true;
                
            }


            
            

        }

    
    }

    



    #endregion
}