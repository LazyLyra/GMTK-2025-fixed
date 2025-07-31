using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject glowingRope;
    [SerializeField] private GameObject nonGlowingRope;

    [Header("Variables")]
    [SerializeField] private float InteractionDist;
    [SerializeField] private bool isCut = false;
    private Vector3 Direction;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var interactionManager = InteractionManager.instance;
        interactionManager.OnInteract += InteractionManager_OnInteract;
        Transform Child1 = transform.Find("SR");
        if (Child1 != null)
        {
            nonGlowingRope = Child1.gameObject;
        }
        Transform Child2 = transform.Find("GlowSR");
        if (Child2 != null)
        {
            glowingRope = Child2.gameObject;
        }

    }

    private void InteractionManager_OnInteract(object sender, System.EventArgs e)
    {
        if (!isCut)
        {
            CutRope();
        }
        else
        {
            return;
        }
    }

    private void Update()
    {
        Direction = player.transform.position - transform.position;
        if (Direction.magnitude <= InteractionDist)
        {
            nonGlowingRope.SetActive(false);
            glowingRope.SetActive(true);
        }
        else
        {
            nonGlowingRope.SetActive(true);
            glowingRope.SetActive(false);
        }
    }
    private void CutRope()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction, InteractionDist);
        if (hit.collider == null)
        {
            return;
        }
        if (hit.collider.CompareTag("Player"))
        {
            Debug.Log("Cut Rope");
        }
    }
}
