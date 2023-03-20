using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] LayerMask attackLayer;
    [SerializeField] GameObject target;
    bool CanSwing = true;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanSwing)
        {
            anim.SetBool("Swing", true);
            Attack();
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
        RaycastHit[] raycastHit = Physics.BoxCastAll(transform.position, new Vector3(0.5f, 0, 0.5f), Camera.main.gameObject.transform.forward, Quaternion.identity, 5f);
        if(raycastHit.Length > 0)
        {
            foreach (RaycastHit raycast in raycastHit)
            {
                Debug.Log("i hit " + raycast.collider.gameObject.name);
                if (raycast.collider.name != "Capsule" && raycast.collider.name != "Sphere")
                    target.transform.position = raycast.point;
            }
        }
        //RaycastHit hit;
        //Physics.Raycast(transform.position, Camera.main.gameObject.transform.forward, out hit, 5);
        //if (hit.collider.name != "Capsule" && hit.collider.name != "Sphere")
        //    target.transform.position = hit.point;
    }
    private void OnDrawGizmos()
    {
        Vector3 camPos = Camera.main.gameObject.transform.position;
        Gizmos.DrawCube(new Vector3(camPos.x, camPos.y, camPos.z + 1), new Vector3(1, 1, 1));
    }
}
