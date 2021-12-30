using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public ButtonController leftButton, rightButton;    

    private void Update()
    {
        if (leftButton != null && rightButton != null) {
            if (leftButton.buttonPressed && rightButton.buttonPressed)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
