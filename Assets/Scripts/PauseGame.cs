using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //events allow to stop execute any input while pausing game, make it feel less buggy
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public UnityEvent GamePaused;
    public UnityEvent GameResume;

    private bool isPaused;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //set isPaused true if it was previously false, vise versa
            isPaused = !isPaused;

            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        GamePaused.Invoke();
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GameResume.Invoke();
        pauseMenu.SetActive(false);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("HomeScene");
    }
}
