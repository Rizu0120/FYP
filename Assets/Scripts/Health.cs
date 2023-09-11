using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    TextMesh tm;

    // Use this for initialization
    void Start()
    {
        tm = GetComponent<TextMesh>();
    }

    // Update is called once per fra
    void Update() {
        // Face the Camera
        transform.forward = Camera.main.transform.forward;
    }

    public int current()
    {
        return tm.text.Length;
    }

    // Decrease the current Health by removing one '-'
    public void decrease()
    {
        if (current() > 1)
            tm.text = tm.text.Remove(tm.text.Length - 1); //remove object(health bar) by 1
        else
            // Destroy(transform.parent.gameObject); //when !> 1 destroy player
            transform.parent.gameObject.SetActive(false); //when !> 1 disable player
    }
}