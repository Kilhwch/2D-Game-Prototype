using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject mine, pfShield;
    public Transform attackPoint, playerPoint;
    public LayerMask enemyLayers;
    GameObject shieldInstance;
    AudioManager audiom;
    Animator animator;
    LineRenderer line;
    Vector3 mousePos;

    float attackRange = 0.5f, shieldTimer;
    bool shieldOn = false;
    int waitingTime = 20;

    void Start()
    {
        animator = GetComponent<Animator>();
        audiom = GetComponent<AudioManager>();
        line = GetComponent<LineRenderer>();
    }


    void Update()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Mine
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Mine();

        // Attack
        if (Input.GetKeyDown(KeyCode.Mouse1))
            Attack();

        // Shield
        if (Input.GetKeyDown(KeyCode.Alpha1) && !shieldOn)
            Shield();

        // Magic Beam ON
        if (Input.GetKey(KeyCode.Mouse0))
        {
            line.enabled = true;
            MagicBeam();
            
        }

        // Magic Beam OFF
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            line.enabled = false;
        }

        if (shieldOn) {
            shieldInstance.transform.position = playerPoint.transform.position;
            shieldTimer += Time.deltaTime;
            if (shieldTimer > waitingTime)
            {
                DestroyShield();
            }
        }
    }

    void MagicBeam()
    {

        audiom.Play("Beam", true);
        RaycastHit2D enemy = Physics2D.Raycast(attackPoint.position, (mousePos - attackPoint.position), 13f, enemyLayers);

        var difference = mousePos - attackPoint.position;
        var direction = difference.normalized;
        var distance = Mathf.Min(15f, difference.magnitude);
        var endPosition = attackPoint.position + direction * distance;
        line.SetPositions(new Vector3[] { attackPoint.position, endPosition });


        if (enemy.collider != null)
        {
            Debug.Log(enemy.collider.name);
            if (enemy.collider.tag == "Enemy") {
                enemy.collider.GetComponent<Enemy>().takeDamage(100);
            }
        }
    }

    void Attack()
    {
        audiom.Play("HitAir", false);
        animator.SetTrigger("Attack");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in enemies) {
            enemy.GetComponent<Enemy>().takeDamage(100);
        }
    }

    void Shield()
    {
        audiom.Play("Shield", false);
        shieldOn = true;
        shieldInstance = Instantiate(pfShield, playerPoint.position, playerPoint.rotation);
    }

    void Mine()
    {
        Destroy(Instantiate(mine, playerPoint.position, playerPoint.rotation), 3f);
    }

    void DestroyShield()
    {
        shieldOn = false;
        shieldTimer = 0;
        Destroy(shieldInstance);
    }
}
