using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //public bool keyActive_y;
    //public bool keyActive_u;
    //public bool keyActive_i;
    //public bool keyActive_o;
    //public bool keyActive_p;


    private void Awake()
    {
        Instance = this;
        
        //keyActive_y = false;
        //keyActive_u = false;
        //keyActive_i = false;
        //keyActive_o = false;
        //keyActive_p = false;

    }
    void Update()
    {
       
    }
}