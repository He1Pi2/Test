using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemyfollow : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    
    public int health;
    public int damage;
    public float speed;
    private Transform player;
    private Animator anim;
    private float stopTime;
    public float startStopTime;
    public float normalSpeed;
    private player Player;
    public GameObject deathEffect;
    
    private void start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfTipe<Player>();
        normalSpeed = speed;
    }

    private void update()
    {
        if(stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        anim.SetBool("isRunning", true);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(timeBtwAttack <= 0)
            {
                anim.SetTrigger("attack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
    public void OnEnemyAttack()
    {
        Instantiate(deathEffect, player.transform.position,Quaternion.indentity);
        health -= damage;
    }
}