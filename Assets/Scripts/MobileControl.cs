using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControl : MonoBehaviour
{
    Joystick joystick;
    JoyButton joybutton;
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Horizontal != 0 && joystick.Vertical != 0)
        {
            GameManager.instance.currentCharacter.Move(joystick.Horizontal, joystick.Vertical);
        }
        else
        {
            GameManager.instance.currentCharacter.IsMoving = false;
        }

        if (joybutton.isPressed)
        {
            GameManager.instance.currentCharacter.PickUp();
        }
    }
}
