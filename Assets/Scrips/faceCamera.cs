﻿using UnityEngine;
using System.Collections;

public class faceCamera : MonoBehaviour
{
    public Camera m_Camera;

    void Start()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}