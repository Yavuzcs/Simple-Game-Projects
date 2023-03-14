using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed;

    private void Start()
    {
        Destroy(gameObject, 10);
    }
    private void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
    }
}
