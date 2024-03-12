using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Compañero : MonoBehaviour
{
    public GameObject Object;
    public float velocidad;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public float compañeroYPosition;

    public float detectionDistance = 10f;
    public bool hasTargetedEnemy = false;
    public bool detectionIsActived = true;
    private Transform enemyTransform;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        HabilidadHasActived();
    }

    void HabilidadHasActived()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("HabilidadHasActived");
        }
    }
    private void FlipSprite(string Direction)
    {

        if (Direction == "right")
        {
            spriteRenderer.flipX = false;
        }
        else if (Direction == "left")
        {
            spriteRenderer.flipX = true;
        }
    }
    void FollowPlayer()
    {
        if (!hasTargetedEnemy)
        {
            if (Object.transform.position.x > transform.position.x)
            {
                FlipSprite("right");
            }
            else if (Object.transform.position.x < transform.position.x)
            {
                FlipSprite("left");
            }
            transform.position = Vector2.MoveTowards(transform.position, Object.transform.position, velocidad * Time.deltaTime);
        }
    }
    IEnumerator CoolDownDetection(float seconds)
    {
        detectionIsActived = false;
        yield return new WaitForSeconds(seconds);
        detectionIsActived = true;
    }
    private void OnTriggerStay2D(Collider2D Other)
    {
        int EnemyLayer = LayerMask.NameToLayer("Enemigos");

        if (Other.gameObject.layer == EnemyLayer && detectionIsActived)
        {
            enemyTransform = Other.transform;
            hasTargetedEnemy = true;
            float distancia = Vector2.Distance(transform.position, enemyTransform.position);
            if (distancia < detectionDistance)
            {
                FlipSprite(enemyTransform.position.x > transform.position.x ? "right" : "left");
                transform.position = Vector2.MoveTowards(transform.position, enemyTransform.position, velocidad * Time.deltaTime);
            }
            if (distancia < 2)
            {
                animator.SetTrigger("HabilidadHasActived");
            }
            if (distancia < 0.3)
            {
                Destroy(Other.gameObject);
                hasTargetedEnemy = false;
                StartCoroutine(CoolDownDetection(10f));
            }
        }
        
    }
}