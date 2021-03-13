using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    public Slider healthBar;
    [NonSerialized]
    public float speed, health, damage, dist;
    private Vector3 dir;
    public Types type;
    

    public enum Types
    {
        BOMB, SOLDIER, SHOOTER
    }


    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        speed = GameSettings.enemySpeed;
        health = GameSettings.enemyHealth;
        damage = GameSettings.enemyDamage;

        switch (type)
        {
            case Types.BOMB:
                health *= 0.5f;
                break;
            case Types.SOLDIER:
                speed *= 0.5f;
                damage *= 0.75f;
                break;
            case Types.SHOOTER:
                speed *= 0.75f;
                health *= 0.75f;
                damage *= 0.5f;
                break;

        }
        healthBar.maxValue = health;

    }

    void Update()
    {
        if (player == null)
            return;
        dist = Vector2.Distance(player.transform.position, transform.position);
        dir = player.position - transform.position;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        rb.MovePosition(transform.position + (dir.normalized * Time.deltaTime * speed));

        healthBar.value = health;

        if (type.ToString() == "SHOOTER" && dist < 5)
        {
            speed = 0;
            GetComponent<EnemyShooting>().enabled = true;
        }

        if (health <= 0)
        {
            UIHelper.score+=100f;
            Destroy(gameObject);
        }
           


    }
    IEnumerator SoldierDamage()
    {
        while (true && player!=null)
        {
            speed = 0;
            player.GetComponent<PlayerController>().health -= damage;
            yield return new WaitForSeconds(0.5f);
        }
            

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && type.ToString() == "BOMB")
        {
            player.GetComponent<PlayerController>().health -= damage;
            Destroy(gameObject);

        }
        if (col.CompareTag("Player") && type.ToString() == "SOLDIER")
            StartCoroutine(SoldierDamage());
        
    }
    
}
