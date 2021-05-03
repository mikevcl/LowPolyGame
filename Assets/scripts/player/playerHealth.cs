using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public Slider healthBar;
    public healthSystem playerHP = new healthSystem(100);
    //public GameObject trigger;
    //public WinningTrigger triggers;

    // Start is called before the first frame update
    void Start()
    {
        // This will set the health bar value to the players health
        healthBar.value = playerHP.getHealth();
        //triggers = trigger.getComponent<WinningTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        // Testing the healthbar function, press space to get 10 dmg
        /*
        if ( Input.GetKeyDown( KeyCode.Space ) )
       {

           playerHP.Damage(10);
           healthBar.value = playerHP.getHealth();
           Debug.Log("Health:" + playerHP.getHealth());
           

        }*/
        if(playerHP.getHealth() <= 0 || GameObject.Find("helicopter-base").GetComponent<WinningTrigger>().getWin() == true)
            Destroy(gameObject);

    }

    void OnCollisionEnter(Collision collision)
    {
        Enemy other = collision.gameObject.GetComponent<Enemy>();
        if (other)
        {
            FindObjectOfType<AudioManager>().Play("z_attacking");
            playerHP.Damage(30);
            healthBar.value = playerHP.getHealth();
            Debug.Log("Health:" + playerHP.getHealth());
        }
    }

}
