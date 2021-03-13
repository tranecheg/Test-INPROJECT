using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [NonSerialized]
    public float health;
    public Slider healthBar;
    void Start()
    {
        health = GameSettings.playerHealth;
        healthBar.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

        healthBar.value = health;

        if (health < 0)
            Destroy(gameObject);

    }
}
