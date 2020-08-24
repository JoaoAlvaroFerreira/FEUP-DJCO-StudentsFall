using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;

    public AudioSource m_MyAudioSource;
    //Value from the slider, and it converts to volume level
    public TextMeshProUGUI tmp;
 
    public GameObject game;

       public GameObject pauseMenuUI;
    // Update is called once per frame

   
    void Update()
    {
        updatePoints();
        
        if(Input.GetKeyDown(KeyCode.Space)){

            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

     public void Quit(){
        Application.Quit();
    }

    private void updatePoints(){
      tmp.text = "Points: "+ game.GetComponent<TrackPoints>().getPoints().ToString();
    }


    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        m_MyAudioSource.Pause();
    }

    public void Resume(){

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        m_MyAudioSource.Play();

    }
}
