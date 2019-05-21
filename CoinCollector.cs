using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }
   
   
    public AudioSource collectSound;
    public bool isMusicOn = true;

    void OnTriggerEnter(Collider other)
    {
        if (isMusicOn)
        {
            collectSound.Play();
        }
        ScoringSystem.theScore += 10;
        Destroy(gameObject);
    }

    void Update()
    {
        Cursor.visible = true;
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isMusicOn == true)
            {
               collectSound.Stop();
                isMusicOn = false;
            }
            else if (isMusicOn == false)
            {
               
                isMusicOn = true;
            }
        }
    }
}
