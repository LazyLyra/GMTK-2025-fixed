using UnityEngine;

public class TrashEjectionScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D bc;
    [SerializeField] ValveScript valveScript; //drag in scene not prefab

    [Header("Variables")]
    [SerializeField] float upwardVelocity; 
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        valveScript.OnOpenValve += ValveScript_OnOpenValve;
    }

    private void ValveScript_OnOpenValve(object sender, System.EventArgs e)
    {
        rb.velocity = new Vector2(-1, upwardVelocity);
        bc.enabled = false;
    }
    private void FixedUpdate()
    {
        
    }
}
