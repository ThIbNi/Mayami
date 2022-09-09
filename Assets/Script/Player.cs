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
        float moveSpeed = _moveSpeed;

        float VectorMoveX = Input.GetAxis("Horizontal");
        float VectorMoveZ = Input.GetAxis("Vertical");

        float moveX = rb.position.x + moveSpeed * VectorMoveX;
        float moveZ = rb.position.z + moveSpeed * VectorMoveZ;

        //rb.MovePosition(new Vector3(moveX, rb.position.y, moveZ));
        rb.velocity = new Vector3( VectorMoveX, 0f, VectorMoveZ ) * moveSpeed;

        MainCamera.transform.position = rb.position + new Vector3(0f, 50f, 0f);

        GlobalVariables.Move = (Math.Abs(VectorMoveX) + Math.Abs(VectorMoveZ)) != 0;

    }

    private void LateUpdate()
    {
        GlobalVariables.TimeRun = GlobalVariables.Rotate | GlobalVariables.Move | GlobalVariables.Fire;
        Debug.Log("1.TimeRun - " + GlobalVariables.TimeRun + " 2.Rotate - " + GlobalVariables.Rotate + " 3.Move - " + GlobalVariables.Move + " 4.Fire - " + GlobalVariables.Fire);
    }

}
