using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class WinMenu : MonoBehaviour
{
    

    public TextMeshProUGUI tmp;
 
    public GameObject game;
  public GameObject winMenuUI;

    void Update()
    {
        if (GameObject.Find("Game").GetComponent<Controller>().gameWin)
        {
            
            Time.timeScale = 0;
            waitThreeSeconds();
            tmp.text = "Points: "+ game.GetComponent<TrackPoints>().getPoints().ToString();
            winMenuUI.SetActive(true);
            
        }
    }

     IEnumerator waitThreeSeconds(){
         yield return new WaitForSeconds(3);
 
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
