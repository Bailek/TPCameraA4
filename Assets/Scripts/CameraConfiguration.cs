using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
[System.Serializable]
public class CameraConfiguration 
{

    //Variable Public 
    public float yaw;
    public float pitch;
    public float roll;
    public Vector3 pivot;
    public float distance;
    public float fov;
    public Vector3 offset;
    //Methode Publique
    public Quaternion GetRotation(Quaternion Euler) 
    {
        return Euler;
    }

    public Vector3 GetPosition(Vector3 pivot, Vector3 offset)
    {
        return new Vector3(0, 0, 0);
    }

    public void DrawGizmos(Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(pivot, 0.25f);
        Vector3 position = GetPosition(pivot, offset);
        Gizmos.DrawLine(pivot, position);
        Gizmos.matrix = Matrix4x4.TRS(position, GetRotation(Quaternion.Euler(0,0,0)), Vector3.one);
        Gizmos.DrawFrustum(Vector3.zero, fov, 0.5f, 0f, Camera.main.aspect);
        Gizmos.matrix = Matrix4x4.identity;
    }
}
    
