using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("ClickOne");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void OptionsButton()
    {
        FindObjectOfType<AudioManager>().Play("ClickOne");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        FindObjectOfType<AudioManager>().Play("ClickOne");
        Application.Quit();
    }

    public void BackButton(){
        FindObjectOfType<AudioManager>().Play("ClickTwo");
    }
}
