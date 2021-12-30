using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform EnemyPoint;
    float maxHealth = 500f, currentHealth, beamTimer, waitingTime = 1f;
    bool canTakeBeamDamage, dead = false;
    Animator anim;
    Rigidbody2D body;
    AudioManager audiom;
    EnemyHealthBar healthBar;
    DmgPopupInstance dmgPopup;

    public void Start()
    {
        currentHealth = maxHealth;
        audiom = GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
        anim.SetBool("Grounded", true);
        body = GetComponent<Rigidbody2D>();
        healthBar = GetComponent<EnemyHealthBar>();
        healthBar.initHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        dmgPopup = GetComponent<DmgPopupInstance>();
    }


    void Update()
    {
        if (!dead) { 
            beamTimer += Time.deltaTime;
            if (beamTimer > waitingTime)
            {
                canTakeBeamDamage = true;
            }
        }
    }

    public void takeDamage(int damage)
    {
        if (diesNextHit(damage))
        {
            dmgPopup.Clear();
            Die();
        }

        else if (canTakeBeamDamage)
        {
            dmgPopup.CreateDamagePopup(damage, EnemyPoint);
            audiom.Play("GetHit", false);
            currentHealth -= damage;
            canTakeBeamDamage = false;
            beamTimer = 0;
            healthBar.SetHealth(currentHealth);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    bool diesNextHit(int damage)
    {
        return (currentHealth - damage) <= 0;
    }
}
