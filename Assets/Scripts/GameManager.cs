using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //enable UI function

public class GameManager : MonoBehaviour
{
    public int currentCollectable;
    public Text collectableText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //update score
    public void AddCollectable(int collectableToAdd)
    {
        currentCollectable += collectableToAdd; //from the current score
        collectableText.text = "Score: " + currentCollectable; //text "Score: num"
    }
}
