using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool isDead;

    public float velocity = 1f;
    public Rigidbody2D rb2D;

    public KeepingScore KeepScore;

    public GameObject DeathScreen;

    void Start()
    {
        Time.timeScale = 1;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //havada ku�u s��ratma
            rb2D.velocity = Vector2.up * velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ScoreArea")
        {
            KeepScore.UpdateScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death field")
        {
            isDead = true;
            Time.timeScale = 0;

            DeathScreen.SetActive(true);
        }
    }
}
