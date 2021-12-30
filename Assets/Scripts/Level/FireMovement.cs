using UnityEngine;

public class FireMovement : MonoBehaviour
{
    public AudioManager audiom;
    float speed = 7f;
    public Rigidbody2D body;

    void Awake()
    {
        body.velocity = -transform.right * speed;
        audiom = GetComponent<AudioManager>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        
        if (player != null)
        {
            player.takeDamage(100);
            Destroy(gameObject);
        }

        if (collision.name == "Shield(Clone)")
        {
            audiom.Play("FireHit", false);
            Destroy(gameObject, 0.2f);
        }
    }
}
