using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //enable change scene function

public class Health : MonoBehaviour
{
    TextMesh tm;

    public AudioSource hurtSound;

    // Use this for initialization
    void Start()
    {
        tm = GetComponent<TextMesh>(); //tm = TextMesh
    }

    // Update is called once per fra
    void Update() {
        // Face the Camera
        transform.forward = Camera.main.transform.forward;
    }

    public int current()
    {
        return tm.text.Length; //get health bar length status
    }

    // Decrease the current Health by removing one '-'
    public void decrease()
    {
        hurtSound.Play();
        
        if (current() > 1)
            tm.text = tm.text.Remove(tm.text.Length - 1); //remove object(health bar) by 1
        else
            // Destroy(transform.parent.gameObject); //when !> 1 destroy player, disabled
            transform.parent.gameObject.SetActive(false); //when !> 1 disable player
    }
}