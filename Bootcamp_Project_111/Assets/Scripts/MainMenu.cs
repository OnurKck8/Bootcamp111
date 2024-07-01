using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject maincanvas;
    [SerializeField]
    GameObject optionscanvas;
    public void playLocal()
    {

    }
    public void playOnline()
    {

    }
    public void options()
    {
        //SceneManager.LoadScene("OptionsMenu");
        maincanvas.SetActive(false);   
        optionscanvas.SetActive(true);
        Debug.Log("hata");
    }
    public void quit()
    {
        Application.Quit();
    }
    public void HomeButton()
    {
        //SceneManager.LoadScene("mainmenu");
        maincanvas.SetActive(true);
        optionscanvas.SetActive(false);
       
    }
}
