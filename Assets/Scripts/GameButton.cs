using System.Collections; //auto generated
using System.Collections.Generic; //auto generated
using UnityEngine; //auto generated
using UnityEngine.SceneManagement; //call scene management from unity engine to enable scene switching function

//auto generated
public class GameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //add switch scene function for button clicked
    //public means we can apply this function for certain button, else it will not appear in the selection
    //ButtonClicked() indicates when the button was clicked
    public void ButtonClicked()
    {
        SceneManager.LoadScene("GameScene"); //load current scene to certain scene, in this case is GameScene
    }
}
