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
        maincanvas.SetActive(false);   
        optionscanvas.SetActive(true);
      
    }
    public void quit()
    {
        Application.Quit();
    }
    public void HomeButton()
    {
        maincanvas.SetActive(true);
        optionscanvas.SetActive(false);
       
    }
}
