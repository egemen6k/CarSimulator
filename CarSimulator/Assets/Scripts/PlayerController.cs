using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    [SerializeField] private float horsePower = 0;
    [SerializeField] private float turnSpeed = 40f;
    private float horizontalInput,forwardInput;
    private Rigidbody _rbPlayer;
    [SerializeField] private GameObject _centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private List<WheelCollider> wheelColliders;
    [SerializeField] private int wheelsOnGround;

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

        if (isOnGround())
        {
            _rbPlayer.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            //transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.text = "RPM: " + rpm;

            speed = Mathf.Round(_rbPlayer.velocity.magnitude * 2.237f);
            speedometerText.text = "Speed: " + speed + "mph";
        }
    }

    bool isOnGround()
    {
        wheelsOnGround = 0;

        foreach (WheelCollider wheel in wheelColliders)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
