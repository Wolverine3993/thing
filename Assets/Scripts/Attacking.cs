using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] LayerMask attackLayer;
    [SerializeField] float damage;
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
        Vector3 camPos = Camera.main.gameObject.transform.position;
        RaycastHit[] raycastHit = Physics.BoxCastAll(transform.position, new Vector3(0.5f, 0, 0.5f), Camera.main.gameObject.transform.forward, Quaternion.identity, 2f, attackLayer);
        if(raycastHit.Length > 0)
        {
            foreach (RaycastHit enemy in raycastHit)
            {
                enemy.collider.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            }
        }
    }
}
