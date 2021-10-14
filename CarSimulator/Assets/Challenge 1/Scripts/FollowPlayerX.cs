using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 _offset,_newPosition;

    // Start is called before the first frame update
    void Start()
    {
        _offset = plane.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _newPosition = new Vector3(transform.position.x, plane.transform.position.y - _offset.y , plane.transform.position.z + _offset.z);
        transform.position = _newPosition;
    }
}
