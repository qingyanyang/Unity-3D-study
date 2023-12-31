using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float ratationThrust = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(ratationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-ratationThrust);
        }
    }

    void ApplyRotation(float ratationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * ratationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
