//Property of Dylan Gleeson
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class health_managment : MonoBehaviour
{
    #region Variables

      public static int health_max = 3;
     public  int health_current;
     public int num_of_hearts;
     private int num_of_hearts_max;
    public int dmg = 1;
    private bool hit = false;
    private bool alive = true;

    public Image[] hearts;
    public Sprite full_hearts;
    public Sprite empty_hearts;

    private GameObject player;

    public Text health_text;

    public AudioSource sound;
    public AudioSource game_over;


    #endregion


    #region Methods

    void Start()
    {
       
        health_current = health_max;

        player = GameObject.FindGameObjectWithTag("Player");

        num_of_hearts_max = hearts.Length;

        sound = GetComponent<AudioSource>();
    }


    void Update()
    {
        health_text.text = "= " + health_max;

        
        if(health_current > health_max)
        {
            health_current = health_max;
        }

        if (health_max > num_of_hearts_max)
        {
            health_max = num_of_hearts;
        }

		#region loop
		num_of_hearts = health_max;

        for (int i = 0; i < hearts.Length; i++)
        {
            if( i < health_current)
            {
                hearts[i].sprite = full_hearts;
            }
            else
            {
                hearts[i].sprite = empty_hearts;
            }

            if(i < num_of_hearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

		#endregion


		if (health_current <= 0)
        {
            if (alive)
            {
                StartCoroutine(die());
            }
            
           
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "heart")
        {
            health_current += 1;
            

            Destroy(collision.gameObject);
        }


        #region knockback

        if (player.GetComponent<player_controller2D>().dashed == false)
        {
            
                if (collision.tag == "enemy" && collision.transform.position.x < transform.position.x)
                {

                    player.GetComponent<player_controller2D>().knock_from_right = false;
                    player.GetComponent<player_controller2D>().knockback_count = player.GetComponent<player_controller2D>().knockback_time;

                    if (!hit)
                    {
                        StartCoroutine(dmg_player());
                    }

                }

                if (collision.tag == "enemy" && collision.transform.position.x > transform.position.x)
                {

                    player.GetComponent<player_controller2D>().knock_from_right = true;
                    player.GetComponent<player_controller2D>().knockback_count = player.GetComponent<player_controller2D>().knockback_time;

                    if (!hit)
                    {
                        StartCoroutine(dmg_player());
                    }

                }
            

            

        }
		#endregion
	}

    private void OnTriggerExit(Collider other)
    {
        if (hit)
        {
            hit = false;
        }
    }


    public IEnumerator dmg_player()
    {
        hit = true;
        health_current -= dmg;
        yield return new WaitForSeconds(1);

        hit = false;
        
    }

    public void heal()
    {
        health_current = health_max;
    }


	IEnumerator die()
    {
        alive = false;
        sound.Stop();
        game_over.Play();
        yield return new WaitForSeconds(game_over.clip.length);

        SceneManager.LoadScene("Level 1");
        
    }

    #endregion
}