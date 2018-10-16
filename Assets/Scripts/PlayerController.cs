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
    public Vector2 SmoothV;
    public Vector2 MouseLook;

    public bool IsStearing;

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
        transform.TransformDirection(Vector3.forward);
        transform.Translate(new Vector3(Translation_X, 0, Translation_Z));
    }

    public void BodyRotation()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md,  new Vector2(Camera_Sensitivity * Camera_Smoothing, Camera_Sensitivity * Camera_Smoothing));
        SmoothV.x = Mathf.Lerp(SmoothV.x, md.x, 1f / Camera_Smoothing);
        SmoothV.y = Mathf.Lerp(SmoothV.y, md.y, 1f / Camera_Smoothing);
        MouseLook += SmoothV;

        FPCamera.transform.localRotation = Quaternion.AngleAxis(-MouseLook.y, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(MouseLook.x, transform.up);
    }

    public void ShipSteering()
    {
        
    }
}
