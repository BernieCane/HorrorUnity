﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    public GameObject hud;
    


    public GameObject animateOB;
    public Animator ANI;


    public Text textOB;
    public string answer = "12345";

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;

    public bool animate;


    void Start()
    {
        keypadOB.SetActive(false);

    }


    public void Number(int number)
    {
        textOB.text += number.ToString();
        button.Play();
    }

    public void Execute()
    {
        if (textOB.text == answer)
        {
            correct.Play();
            textOB.text = "Right";

        }
        else
        {
            wrong.Play();
            textOB.text = "Wrong";
        }


    }

    public void Clear()
    {
        {
            textOB.text = "";
            button.Play();
        }
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
        hud.SetActive(true);
        player.GetComponent<SlenderPlayerController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        if (textOB.text == "Right" && animate)
        {
            ANI.SetBool("Open", true);
            Debug.Log("its open");
        }


        if(keypadOB.activeInHierarchy)
        {
            hud.SetActive(false);
            player.GetComponent<SlenderPlayerController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }


}
