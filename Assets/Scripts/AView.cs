using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AView : MonoBehaviour
{
    public float weight;
    public bool isActiveOnStart;
    public CameraConfiguration camConfiguration = new CameraConfiguration();
    private void Start()
    {
        if (isActiveOnStart)
        {
            SetActive(true);
        }
    }
    public virtual CameraConfiguration GetConfiguration()
    {
        return camConfiguration;
    }
    public void SetActive(bool isActive)
    {
        CameraController.Instance.AddView(gameObject.GetComponent<FixedView>());
    }
    
}
