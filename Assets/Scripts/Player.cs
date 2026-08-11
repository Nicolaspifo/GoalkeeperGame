using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Control del movimiento (Tecla P)
        if (Keyboard.current != null && Keyboard.current.pKey.isPressed)
        {
            anim.SetBool("semueve", true);
        }
        else
        {
            anim.SetBool("semueve", false);
        }

        // Control del movimiento (Tecla P)
        if (Keyboard.current != null && Keyboard.current.spaceKey.isPressed)
        {
            anim.SetBool("salta", true);
        }
        else
        {
            anim.SetBool("salta", false);
        }


    
    }
}
