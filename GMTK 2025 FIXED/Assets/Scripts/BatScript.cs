using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    [Header("variables")]
    [SerializeField] private float chaseDistance = 5f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float moveDuration = 3f;
    [SerializeField] private float cooldownDuration = 2f;
    [SerializeField] bool IsFacingRight;

    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject breakEffectPrefab;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] GameObject exclaimationMark;
    public AudioSource AS;
    [SerializeField] AudioClip breakDoor;

    private float moveTimer = 0f;
    private float cooldownTimer = 0f;
    private bool isChasing = false;
    private Vector2 chaseDirection;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        AS = GetComponent<AudioSource>();
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        IsFacingRight = true;
        Transform Child1 = transform.Find("!");
        if (Child1 != null)
        {
            exclaimationMark = Child1.gameObject;
        }
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (isChasing)
        {
            moveTimer -= Time.deltaTime;

            if (moveTimer <= 0f)
            {
                isChasing = false;
                cooldownTimer = cooldownDuration;
                rb.velocity = Vector2.zero;

                
            }
        }
        else
        {
            if (cooldownTimer > 0f)
            {
                cooldownTimer -= Time.deltaTime;
            }
            else if (distanceToPlayer <= chaseDistance)
            {
                RaycastHit2D Hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
                Debug.Log(Hit.collider.name);
                if (Hit.collider == null)
                {
                    Debug.Log("collider is null");
                    return;
                }
                if (Hit.collider.gameObject == player && distanceToPlayer < chaseDistance)
                {
                    isChasing = true;
                    moveTimer = moveDuration;
                    chaseDirection = (player.transform.position - transform.position).normalized;
                    rb.velocity = chaseDirection * moveSpeed;
                    StartCoroutine(ShowExcalmationMark());
                    CheckFlip();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (isChasing)
        {
            rb.velocity = chaseDirection * moveSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            if (breakEffectPrefab != null)
            {
                Instantiate(breakEffectPrefab, collision.transform.position, Quaternion.identity);
                AS.PlayOneShot(breakDoor);
            }

            Destroy(collision.gameObject);
        }
    }
    private IEnumerator ShowExcalmationMark()
    {
        exclaimationMark.SetActive(true);
        yield return new WaitForSeconds(1f);
        exclaimationMark.SetActive(false);
    }
    void CheckFlip()
    {
        if (IsFacingRight && rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            IsFacingRight = !IsFacingRight;
        }
        else if (!IsFacingRight && rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            IsFacingRight = !IsFacingRight;
        }
    }
}
