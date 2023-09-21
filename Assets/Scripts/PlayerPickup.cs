using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //enable change scene function

public class PlayerPickup : MonoBehaviour
{
    public AudioSource pickSound; //sound

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pickup"){
            other.gameObject.SetActive(false); //collectable dissapear when collide
            score+=1; //add 1 score when collected
            print("score="+ score); //console check
            // if(score ==12) //when score reach 12
            // {
            //     print("Victory"); //console status check
            //     SceneManager.LoadScene ("WinScene"); //navigate to end scene
            // }
            pickSound.Play(); //play sound
        }

        if(other.gameObject.tag == "Goal")
        {
            other.gameObject.SetActive(false); //touched object dissapear when collide
            print("Victory"); //console status check
            SceneManager.LoadScene ("WinScene"); //navigate to end scene
        }
    }
}
