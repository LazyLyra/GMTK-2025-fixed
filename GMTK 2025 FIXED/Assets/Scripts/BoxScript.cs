using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    [SerializeField] private RopeScript ropeScript;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        ropeScript.OnRopeCut += RopeScript_OnRopeCut;
    }

    private void RopeScript_OnRopeCut(object sender, System.EventArgs e)
    {
        rb.isKinematic = false;
    }
}
