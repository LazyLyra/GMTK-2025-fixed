using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UnpushableByPlayer : MonoBehaviour
{
    public float pushForce = 2f;
    private Rigidbody2D rb;
    [SerializeField] private int pushableLayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pushableLayer = LayerMask.NameToLayer("Pushable");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == pushableLayer)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
        }
    }
}
