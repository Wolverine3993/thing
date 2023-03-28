using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordAttacking : MonoBehaviour
{
    [SerializeField] LayerMask player;
    [SerializeField] float damage;
    void Attack()
    {
        RaycastHit raycastHit;
        bool hit = Physics.BoxCast(transform.position, new Vector3(0.5f, 0, 0.5f), transform.forward, out raycastHit, Quaternion.identity, 1.68f, player);
        if (hit)
        {
            raycastHit.rigidbody.GetComponent<PlayerHealth>().Damage(damage);
        }
    }
}
