using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSplash : MonoBehaviour
{
    [SerializeField] KeyCode enterKey;
    [SerializeField] GameObject splash;
    [SerializeField] GameObject btns;

    public void Start()
    {
        splash.SetActive(true);
        btns.SetActive(false);
    }
    public void Update()
    {
        if(Input.GetKey(enterKey))
        {
            splash.SetActive(false);
            btns.SetActive(true);
        }
    }
}
