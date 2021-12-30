using UnityEngine;
using TMPro;
using System;

public class DamagePopup : MonoBehaviour
{
    TextMeshPro textMesh;
    Transform startPos;
    float timer = 0, waitingTime = 1, yPos;

    void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public void Setup(Transform startPosRef, int damage)
    {
        startPos = startPosRef;
        textMesh.SetText(damage.ToString());
        yPos = startPos.position.y;
    }

    void Update()
    {
        transform.position = new Vector2(startPos.position.x, yPos += 0.01f);
        timer += Time.deltaTime;
        if (timer > waitingTime)
            {
                Destroy(gameObject);
            }
     }

    public void Clear()
    {
        Destroy(gameObject);
    }
}
