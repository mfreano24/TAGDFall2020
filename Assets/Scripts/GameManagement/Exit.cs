﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameManager gm;
    public MainUI mui;
    private void OnEnable()
    {
        Debug.Log("Finding new GameManagers for the exit particles!");
        //this automatically sets them but hopefully i remember that further down the development pipeline >:3c
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        mui = GameObject.Find("Canvas").GetComponent<MainUI>();
    }

    private void Update()
    {
        //PLEASE COMMENT THIS OUT ON BUILDS
        //DEBUG LEVEL SKIPPER
        /*
        if (Input.GetKeyDown(KeyCode.K))
        {
            endOfLevel();
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !gm.roundOver)
        {
            other.gameObject.GetComponent<FootstepAudio>().MuteFeet();
            other.gameObject.GetComponent<PlayerHealth>().ExitImmunity();
            endOfLevel();
        }
    }


    void endOfLevel()
    {
        AudioManager.singleton.PlaySFX("teleport"); //see if this works, may need to play delayed?
        Debug.Log("End of Level Trigger Entered!");
        mui.ExitFound();
        gm.playerWin = true;
        gm.roundOver = true;
    }
}
