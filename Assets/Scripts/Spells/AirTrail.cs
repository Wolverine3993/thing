using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTrail : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    Vector3 camFwd;
    private void Start()
    {
        camFwd = Camera.main.transform.forward;
        body = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        body.velocity = camFwd * speed;
    }
}
