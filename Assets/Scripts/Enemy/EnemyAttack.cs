using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform attackPoint;
    public Transform PlayerAbovePoint;
    public GameObject fire;
    public GameObject fallingFire;

    Animator animator;
    float fireTimer, fallingFireTimer;
    int cooldown_fire = 2, cooldown_fallingFire = 5;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("Grounded", true);
        fireTimer += Time.deltaTime;
        fallingFireTimer += Time.deltaTime;

        if (fireTimer > cooldown_fire)
        {
            Fire();
            fireTimer = 0;
        }

        if (fallingFireTimer > cooldown_fallingFire)
        {
            //FallingFire();
            fallingFireTimer = 0;
        }
    }

    void Fire()
    {
        Destroy(Instantiate(fire, attackPoint.position, attackPoint.rotation), 3f);
    }

    void FallingFire()
    {
        Destroy(Instantiate(fallingFire, PlayerAbovePoint.position, fallingFire.transform.rotation), 4f);
    }
}
