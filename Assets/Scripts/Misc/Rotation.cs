using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        var rotation = transform.rotation.eulerAngles + transform.up * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
