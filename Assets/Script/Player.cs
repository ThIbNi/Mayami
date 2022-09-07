using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 20f;
    [SerializeField] private Camera MainCamera;
    private Rigidbody rb;

    //float smoothTime = 0.3f;
    //private Vector3 velocity = Vector3.zero;

    void Start()
    {
        rb = GetComponent <Rigidbody> ();
    }

    void FixedUpdate()
    {
        //MainCamera.transform.position = Vector3.SmoothDamp(transform.position, rb.position + new Vector3(0f, 1110f, 0f), ref velocity, smoothTime);
        MainCamera.transform.position = rb.position + new Vector3(0f, 50f, 0f);
    }

    void Update()
    {
        
        float moveSpeed = _moveSpeed;

        float VectorMoveX = Input.GetAxis("Horizontal");
        float VectorMoveZ = Input.GetAxis("Vertical");

        float moveX = rb.position.x + moveSpeed * VectorMoveX * Time.deltaTime ;
        float moveZ = rb.position.z + moveSpeed * VectorMoveZ * Time.deltaTime ;

        rb.MovePosition(new Vector3(moveX, rb.position.y, moveZ));
   
        

    }

}
