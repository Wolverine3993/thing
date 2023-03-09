using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    [Header("Camera")]
    GameObject cameraObject;
    [SerializeField] float cameraSensitivity;
    float yRot;
    [Header("Movement")]
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpHeight;
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
        text.text = $"Velocity X: {rb.velocity.x} \nVelocity Z: {rb.velocity.z}";
    }
}
