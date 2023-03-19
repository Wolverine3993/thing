using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] Animator anim;
    bool CanSwing = true;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanSwing)
        {
            anim.SetBool("Swing", true);
            CanSwing = false;
        }
    }
    public void SetSwingTrue()
    {
        anim.SetBool("Swing", false);
        CanSwing = true;
    }
}
