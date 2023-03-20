using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] LayerMask attackLayer;
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
    public void Attack()
    {
        RaycastHit[] raycastHit = Physics.BoxCastAll(transform.position, new Vector3(), transform.forward, Quaternion.Euler(0, 0, 0), 10f, attackLayer);
    }
}
