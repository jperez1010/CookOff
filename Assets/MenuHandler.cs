using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject startButton;
    public GameObject quitButton;
    public GameObject hostButton;
    public GameObject joinButton;

    public void PressStart()
    {
        startButton.SetActive(false);
        quitButton.SetActive(false);

        hostButton.SetActive(true);
        joinButton.SetActive(true);
    }

    public void PressQuit()
    {
        Application.Quit();
    }

    public void PressHost()
    {

    }

    public void PressJoin()
    {
        //TODO
    }
}
