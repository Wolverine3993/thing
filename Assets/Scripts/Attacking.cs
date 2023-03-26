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
    [SerializeField] Transform[] spellPoint;
    bool haveEffects = false;
    private KeyCode[] numbers =
    {
        KeyCode.Alpha1,KeyCode.Alpha2,KeyCode.Alpha3,KeyCode.Alpha4,KeyCode.Alpha5,KeyCode.Alpha6
    };
    /* Order:
     * Air, 
     * Fire,
     * 
     */
    int currentSpellNum = 0;
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
            if (haveEffects)
            {
                for (int i = 0; i < spellEffects.Length; i++)
                {
                    if (spellEffects[i].activeInHierarchy == true && i != currentSpellNum)
                        spellEffects[i].SetActive(false);
                    else if (spellEffects[i].activeInHierarchy == false && i == currentSpellNum)
                        spellEffects[i].SetActive(true);
                }
                for(int i = 0; i < numbers.Length; i++)
                {
                    if (Input.GetKeyDown(numbers[i]))
                    {
                        currentSpellNum = i;
                    }
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("DoCast", true);
                foreach(GameObject spellEffect in spellEffects)
                    spellEffect.SetActive(false);
                haveEffects = false;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                SetBoolsFalse();
                foreach (GameObject spellEffect in spellEffects)
                    spellEffect.SetActive(false);
                haveEffects = false;
            }
        }

    }
    public void Cast()
    {
        GameObject clone = GameObject.Instantiate(spells[currentSpellNum], spellPoint[currentSpellNum].position, Quaternion.identity);
        clone.SetActive(true);
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
        haveEffects = true;
    }
    public void Attack()
    {
        Vector3 camPos = Camera.main.gameObject.transform.position;
        RaycastHit[] raycastHit = Physics.BoxCastAll(transform.position, new Vector3(0.75f, 0, 0.5f), Camera.main.gameObject.transform.forward, Quaternion.identity, 1.5f, attackLayer);
        if (raycastHit.Length > 0)
        {
            foreach (RaycastHit enemy in raycastHit)
            {
                enemy.collider.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            }
        }
    }
    public RaycastHit[] AirSpell()
    {
        return Physics.BoxCastAll(transform.position, new Vector3(1f, 0.5f, 0.5f), Camera.main.gameObject.transform.forward, Quaternion.identity, 3f, attackLayer);
    }
}
