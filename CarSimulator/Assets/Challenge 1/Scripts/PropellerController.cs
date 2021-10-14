using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerController : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.forward * 150f * Time.deltaTime);
    }
}
