using System.Collections;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool buttonPressed = false;

    public void PressButton()
    {
        if (!buttonPressed) {
            StartCoroutine(WaitCoroutine());
        }
    }

    IEnumerator WaitCoroutine()
    {
        buttonPressed = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(10);
        buttonPressed = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
