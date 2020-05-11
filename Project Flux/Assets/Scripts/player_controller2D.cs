//Property of Dylan Gleeson
using System;
using System.Collections;
using UnityEngine;

public class player_controller2D : MonoBehaviour
{
    #region Variables

    private Rigidbody2D rb;
    public float spd;
    public float jump_force;
    private float move_input;
    public bool looking_right;
    private float spd_lock;
    //private float jump_force_lock;

    private bool is_grounded;
    public Transform ground_check;
    private float check_radius = 0.2f;
    public LayerMask what_is_ground;
    private float jump_time_counter;
    public float jump_time;
    private bool is_jumping;
    static public int extra_jump = 0;
    private int extra_jump_value;



    public bool hit;
    public float knockback;
    public float knockback_time;
    public float knockback_count;
    public bool knock_from_right;


    public float dash_spd;
    private float dash_time;
    public float start_dash_time;
    private int direction;
    private bool can_dash = true;
    public bool dashed;
    public float dash_cooldown_time;
    public ParticleSystem dash_effect;



    #endregion


    #region Methods
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dash_time = start_dash_time;

        spd_lock = spd;
        

        extra_jump_value = extra_jump;
    }


    void Update()
    {

        #region Movement
        
        if(knockback_count <= 0)
        {
            move_input = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move_input * spd, rb.velocity.y);
            hit = false;
        }
        else
        {
            hit = true;
            if (knock_from_right)
            {
                rb.velocity = new Vector2(-knockback, knockback);
            }
            if (!knock_from_right)
            {
                rb.velocity = new Vector2(knockback, knockback);
            }
            knockback_count -= Time.deltaTime;
        }
            

       

        #endregion


        #region Flip

        if (move_input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            looking_right = true;


        }
        else if (move_input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            looking_right = false;

        }


        #endregion


        #region Jumping

        is_grounded = Physics2D.OverlapCircle(ground_check.position, check_radius, what_is_ground);

        if(is_grounded == true)
        {
            extra_jump_value = extra_jump;
        }


        if (Input.GetKeyDown(KeyCode.Space) && extra_jump_value > 0)
        {
            is_jumping = true;
           // jump_time_counter = jump_time;
            rb.velocity = Vector2.up * jump_force;
            extra_jump_value--;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && extra_jump_value == 0 && is_grounded == true)
        {
            is_jumping = true;
           // jump_time_counter = jump_time;
            rb.velocity = Vector2.up * jump_force;
        }
        
        if (Input.GetKey(KeyCode.Space) && is_jumping == true)
        {
          // if(jump_time_counter > 0)
           // {
                rb.velocity = Vector2.up * jump_force;
               // jump_time_counter -= Time.deltaTime;
                is_grounded = false;
          //  }
          //  else
           // {
                is_jumping = false;
           // }
        }

      


		#endregion


		#region Dash

        if(direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) && can_dash == true)
            {
               if(looking_right == true)
               {
                    direction = 1;
                    
                } 
               else if (looking_right == false)
               {
                  direction = 2;
                   
                }
            }
        }
        else
        {
            if(dash_time <= 0)
            {
                direction = 0;
                dash_time = start_dash_time;
               rb.velocity = Vector2.zero;
            }
            else
            {
                dash_time -= Time.deltaTime;

                if (direction == 1)
                {
                    
                    rb.velocity = Vector2.right * dash_spd;
                    dashed = true;
                    can_dash = false;
                    StartCoroutine(dash_cooldown());
                    
                }
                else if (direction == 2)
                {
                    
                    rb.velocity = Vector2.left * dash_spd;
                    dashed = true;
                    can_dash = false;
                    StartCoroutine(dash_cooldown());
                }
            }
        }
       
        if(Input.GetKeyDown(KeyCode.W) && can_dash == true)
        {
            dash_effect.Play();
        }





        #endregion


        #region Knockback


        


        #endregion




    }




    IEnumerator dash_cooldown()
    {
        if(dashed == true)
        {
            yield return new WaitForSeconds(dash_cooldown_time);
            can_dash = true;
            dashed = false;
        }
    }


 
    #endregion
}