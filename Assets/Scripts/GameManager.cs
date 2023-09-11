using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void AddCollectable(int collectableToAdd)
    {
        currentCollectable += collectableToAdd;
        collectableText.text = "Score: " + currentCollectable;
    }
}
