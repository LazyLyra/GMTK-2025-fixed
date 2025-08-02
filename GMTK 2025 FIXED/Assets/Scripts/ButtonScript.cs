using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Rubbish;

    [Header("Variables")]
    [SerializeField] private bool isPressed = false;
    private Animator Animator;
    private const string pressed = "isPressed";

    public event EventHandler OnButtonPressed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Rubbish = GameObject.FindGameObjectWithTag("Rubbish");
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider == null) return;
        if (collision.collider.CompareTag("Rat")){
            isPressed = true;
            Animator.SetBool(pressed, isPressed);
        }
    }

    void pressButton()
    {
        OnButtonPressed?.Invoke(this, EventArgs.Empty);
    }
}
