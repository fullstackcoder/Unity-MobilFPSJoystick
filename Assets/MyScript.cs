using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    protected Joystick joystick;
    protected JoyButton joyButton;

    protected bool jump;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joyButton = FindObjectOfType<JoyButton>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * 100f, rigidbody.velocity.y, joystick.Vertical * 100f);

        if (!jump && joyButton.Pressed)
        {
            jump = true;
            rigidbody.velocity += Vector3.up * 50f;
        }
        if (jump && !joyButton.Pressed)
        {
            jump = false;
            rigidbody.velocity -= Vector3.up * 25f;
        }
    }
}
