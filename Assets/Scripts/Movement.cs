using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class Movement : MonoBehaviour
{
    [Header("Camera")]
    GameObject cameraObject;
    [SerializeField] float cameraSensitivity;
    float yRot;
    [Header("Movement")]
    [SerializeField] float movementSpeed;
    [SerializeField] float maxSpeed;
    [Header("Jumping")]
    [SerializeField] float jumpHeight;
    [SerializeField] LayerMask groundLayer;
    Rigidbody rb;
    Collider coll;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraObject = Camera.main.gameObject;
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }
    private void Update()
    {
        DoCameraShenanigans();
        TouchingGround();
    }
    private void FixedUpdate()
    {
        DoMovement();
    }
    private void DoCameraShenanigans()
    {
        float mouseX = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        transform.Rotate(new Vector3(0, mouseX, 0));
        yRot -= mouseY;
        yRot = Mathf.Clamp(yRot, -90, 90);
        cameraObject.transform.localRotation = Quaternion.Euler(yRot, 0, 0);
    }
    private void DoMovement()
    {
        float z = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 move = transform.forward * z + transform.right * x;
        rb.AddForce(new Vector3(move.x, 0, move.z).normalized * movementSpeed);
        Vector3 targetThing = Vector3.ClampMagnitude(new Vector3(rb.velocity.x, 0, rb.velocity.z), maxSpeed);
        if(new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude > maxSpeed)
            rb.velocity = new Vector3(targetThing.x, rb.velocity.y, targetThing.z);
        Vector3 zVel = rb.velocity / 2;
        zVel.y = rb.velocity.y;
        rb.velocity = zVel;
    }
    private bool TouchingGround()
    {
        Vector3 center = coll.bounds.center;
        center.y = coll.bounds.min.y - 0.001f;

        Vector3 halfExtents = new Vector3((coll.bounds.size.x - 0.1f)/2, 0.05f, (coll.bounds.size.z - 0.1f)/2);

        bool raycastHit = Physics.BoxCast(center, halfExtents, Vector3.down, Quaternion.Euler(0, 0, 0), 0.1f, groundLayer);
        Debug.Log(raycastHit);
        return raycastHit;
    }
    private void OnDrawGizmos()
    {
        Vector3 center = coll.bounds.center;
        center.y = coll.bounds.min.y - 0.001f;
        Vector3 halfExtents = new Vector3((coll.bounds.size.x - 0.1f) / 2, 0.05f, (coll.bounds.size.z - 0.1f) / 2) * 2;
        Gizmos.DrawCube(center, halfExtents);
    }
}
