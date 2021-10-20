using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private float speed = 20f;
    [SerializeField] private float horsePower = 0;
    [SerializeField] private float turnSpeed = 40f;
    private float horizontalInput,forwardInput;
    private Rigidbody _rbPlayer;
    [SerializeField] private GameObject _centerOfMass;

    private void Start()
    {
        _rbPlayer = GetComponent<Rigidbody>();
        _rbPlayer.centerOfMass = _centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        /*Vector3 force = transform.TransformDirection(Vector3.forward * forwardInput * horsePower);
        _rbPlayer.AddForce(force); */
        _rbPlayer.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
        //transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);
    }
}
