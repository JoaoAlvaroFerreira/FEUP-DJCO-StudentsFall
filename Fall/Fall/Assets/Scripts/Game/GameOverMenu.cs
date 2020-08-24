using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverMenu : MonoBehaviour
{

    
    public TextMeshProUGUI tmp;
 
    public GameObject game;

    public GameObject deadMenuUI;

    void Update()
    {
        if (GameObject.Find("Character").GetComponent<DamageCheck>().state == State.Dead)
        {
            
            Time.timeScale = 0;
            tmp.text = "Points: "+ game.GetComponent<TrackPoints>().getPoints().ToString();
            deadMenuUI.SetActive(true);

        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
