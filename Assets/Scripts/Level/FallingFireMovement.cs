using UnityEngine;
public class FallingFireMovement : MonoBehaviour
{
    float speed = 5f;
    public Rigidbody2D body;

    void Start()
    {
        body.velocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            player.takeDamage(100);
            Destroy(gameObject);
        }

        if (collision.name == "Shield(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
