using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    public Slider slider;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 1);
    }

    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
    }

    public void initHealth(float health)
    {
        slider.value = health;
        slider.maxValue = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
