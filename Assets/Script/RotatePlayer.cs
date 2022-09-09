using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float offset = 0;
    private Transform PlayerTransform;
    [SerializeField] private int WScrin = 1920;
    [SerializeField] private int HScrin = 1080;

    private Quaternion LastRotation;

    void Start()
    {
        PlayerTransform = GetComponent<Transform>();
        LastRotation = PlayerTransform.rotation;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        float rotY = - Mathf.Atan2(HScrin / 2f - mousePos.y, WScrin / 2f - mousePos.x) * Mathf.Rad2Deg;
        PlayerTransform.rotation = Quaternion.Euler(0f, rotY + offset, 0f);

        GlobalVariables.Rotate = PlayerTransform.rotation != LastRotation;
        LastRotation = PlayerTransform.rotation;
    }
}
