using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    public AudioSource src; //audio search

    public AudioClip buttonH, buttonC; //sound 1, 2

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //playOneShot() allows you to play multiple instances of the same sound. 
    //if call play() on an already playing sound nothing happens unless the sound is done playing.
    //assigning different function for different track
    public void hoverSound()
    {
        src.PlayOneShot(buttonH);
    }


    public void clickSound()
    {
        src.PlayOneShot(buttonC);
    }
}
