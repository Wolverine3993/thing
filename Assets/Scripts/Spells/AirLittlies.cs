using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirLittlies : MonoBehaviour
{
    [SerializeField] float angle;
    int z;
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, z);
        z++;
    }
}
