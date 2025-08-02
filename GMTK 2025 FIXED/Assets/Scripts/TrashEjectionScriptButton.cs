using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashEjectionScriptButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] private ButtonScript buttonScript; // Drag here

    [Header("Variables")]
    [SerializeField] private float velocity = 10f;
    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (bc == null) bc = GetComponent<BoxCollider2D>();

        if (buttonScript != null)
        {
            buttonScript.OnButtonPressed += ButtonScript_OnButtonPressed;
        }
        else
        {
            Debug.LogWarning("ButtonScript reference missing!");
        }
    }

    private void ButtonScript_OnButtonPressed(object sender, System.EventArgs e)
    {
        Vector2 dir = Vector2.up; 
        rb.velocity = dir * velocity;
        bc.enabled = false; 
    }
}
