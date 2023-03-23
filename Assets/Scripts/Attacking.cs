using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] LayerMask attackLayer;
    [SerializeField] float damage;
    bool canAction = true;
    bool waitForCast = false;
    [SerializeField] GameObject[] spells;
    [SerializeField] GameObject[] spellEffects;
    public enum Spells
    {
        Fire,
        Air
    }
    public Spells currentSpell;
    void Update()
    {
        if (!waitForCast)
        {
            if (Input.GetMouseButtonDown(0) && canAction)
            {
                anim.SetBool("Swing", true);
                canAction = false;
            }
            if (Input.GetKey(KeyCode.F) && canAction)
            {
                anim.SetBool("Cast", true);
                canAction = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("DoCast", true);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                SetBoolsFalse();
            }
        }

    }
    public void Cast(string spell)
    {

    }
    public void SetBoolsFalse()
    {
        waitForCast = false;
        canAction = true;
        anim.SetBool("Cast", false);
        anim.SetBool("DoCast", false);
    }
    public void SetSwingTrue()
    {
        anim.SetBool("Swing", false);
        canAction = true;
    }
    public void SetWait()
    {
        waitForCast = true;
    }
    public void Attack()
    {
        Vector3 camPos = Camera.main.gameObject.transform.position;
        RaycastHit[] raycastHit = Physics.BoxCastAll(transform.position, new Vector3(0.75f, 0, 0.5f), Camera.main.gameObject.transform.forward, Quaternion.identity, 1.5f, attackLayer);
        if(raycastHit.Length > 0)
        {
            foreach (RaycastHit enemy in raycastHit)
            {
                enemy.collider.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            }
        }
    }
}
