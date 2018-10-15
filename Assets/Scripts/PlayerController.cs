using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public float Speed = 1f;
    public Camera FPCamera;
    public float Camera_Sensitivity;
    public float Camera_Smoothing;
    public Rigidbody _Body;
    public Vector2 MousePositionSum;
    public Vector2 MouseRotation;

    // Use this for initialization
    void Start()
    {
        _Body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnUpdate()
    {
    }

    public void Movement()
    {
        float Translation_X = Input.GetAxis("Horizontal") * Speed;
        float Translation_Z = Input.GetAxis("Vertical") * Speed;
        Translation_X *= Time.deltaTime;
        Translation_Z *= Time.deltaTime;
        transform.Translate(new Vector3(Translation_X, 0, Translation_Z));
    }

    public void BodyRotation()
    {
        transform.rotation = new Quaternion(0,FPCamera.transform.rotation.y, 0,0);
    }
}
