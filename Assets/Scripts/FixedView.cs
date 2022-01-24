using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedView : AView
{
    //Variable
    #region Variable
    public float yaw;
    public float pitch;
    public float roll;
    public float fov;

    #endregion
    public override CameraConfiguration GetConfiguration()
    {
        CameraConfiguration camConfiguration = new CameraConfiguration();
        camConfiguration.yaw = yaw;
        camConfiguration.pitch = pitch;
        camConfiguration.roll = roll;
        camConfiguration.fov = fov;
        camConfiguration.pivot = gameObject.transform.position;
        camConfiguration.distance = 0;
        return camConfiguration;
    }
}
