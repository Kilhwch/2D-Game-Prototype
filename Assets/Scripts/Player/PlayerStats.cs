using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    float maxHealth = 500, currhealth;
    public bool dead = false;
    public PlayerHUD hud;


    public void Start()
    {
        currhealth = maxHealth;
        hud.InitHealth(maxHealth);
    }

    public void addHealth()
    {
        if (currhealth < maxHealth) {
            currhealth++;
            hud.SetHealth(currhealth);
        }
    }

    public void updateHealth(float damage)
    {
        if ((currhealth - damage) > 0)
        {
            Debug.Log("Reducing " + damage + " damage from Player Health.");
            currhealth -= damage;
            hud.SetHealth(currhealth);
        }
        else
        {
            hud.SetHealth(0);
            dead = true;
        }
    }

    public bool isDead()
    {
        return dead;
    }

    public string getHealth()
    {
        return "Health: " + currhealth;
    }
}
