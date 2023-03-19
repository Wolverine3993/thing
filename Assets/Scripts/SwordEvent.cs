using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEvent : MonoBehaviour
{
    [SerializeField] Attacking attack;
    void SetSwingTrue()
    {
        attack.SetSwingTrue();
    }
}
