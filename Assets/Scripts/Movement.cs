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
    [SerializeField] float jumpHeight;
    [SerializeField] float maxSpeed;
    [SerializeField] float deceleration;
    Rigidbody rb;
    [SerializeField] TMP_Text text;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraObject = Camera.main.gameObject;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        DoCameraShenanigans();
        
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
        text.text = $"Velocity: {new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude}";
        Vector3 targetThing = Vector3.ClampMagnitude(new Vector3(rb.velocity.x, 0, rb.velocity.z), maxSpeed);
        if(new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude > maxSpeed)
            rb.velocity = new Vector3(targetThing.x, rb.velocity.y, targetThing.z);
        float xVal = 0;
        float zVal = 0;
        if (x == 0)
            xVal = -0.5f;
        if (z == 0)
            zVal = -0.5f;
        Debug.Log(z);
        Vector3 good = rb.velocity.x * transform.right + rb.velocity.z * transform.forward;
        rb.velocity = (new Vector3(good.x, rb.velocity.y, good.z));
    }
}
