using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 fwd;
    [SerializeField] float pushback;
    RaycastHit[] enemies;
    [SerializeField] GameObject trail;
    private void Awake()
    {
        fwd = player.transform.forward;
    }
    private void Start()
    {
        enemies = player.GetComponent<Attacking>().AirSpell();
        foreach (RaycastHit hit in enemies)
        {
            hit.collider.attachedRigidbody.isKinematic = false;
            hit.collider.attachedRigidbody.AddForce(fwd * pushback, ForceMode.Force);
            hit.collider.gameObject.GetComponent<BasicAI>().SetTimerNoKinematic(0.1f);
        }
        GameObject clone = transform.GetChild(0).gameObject;
        clone.SetActive(true);
        clone.transform.parent = null;
        Destroy(clone, 2);
        Destroy(this.gameObject);
    }
}
