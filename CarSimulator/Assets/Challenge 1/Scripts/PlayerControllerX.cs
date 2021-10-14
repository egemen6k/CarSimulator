using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float horizontalInput,verticalInput;
    private Vector3 _moveDirection,_rotateDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        _moveDirection = new Vector3(0f, 0f, horizontalInput);
        transform.Translate(_moveDirection * speed * Time.deltaTime);

        verticalInput = -Input.GetAxis("Vertical");
        _rotateDirection = new Vector3(verticalInput, 0f, 0f);
        transform.Rotate(_rotateDirection * rotationSpeed * Time.deltaTime);
    }
}
