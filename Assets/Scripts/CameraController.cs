using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Singleton
    #region Singleton
    public static CameraController _instance;
    public static CameraController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CameraController>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("CameraController");
                    _instance = container.AddComponent<CameraController>();
                }
            }

            return _instance;
        }
    }
    #endregion
    //Variaible
    #region Variable
    public float AverageYaw;
    public Camera camera;
    private List<AView> activeViews = new List<AView>();
    #endregion
    //Methode
    #region MethodeConfiguration
    private void Start()
    {
        
    }
    private void Update()
    {
        AverageYaw = ComputeAverageYaw();
    }
    public void OnDrawGizmos()
    {
        foreach (AView view in activeViews)
        {
            view.GetConfiguration().DrawGizmos(Color.red);
        }
    }
    public void ApplyConfiguration(Camera camera, CameraConfiguration configuration)
    {

    }
    public void AddView(AView view)
    {
        activeViews.Add(view);
    }
    public void RemoveView(AView view)
    {
        activeViews.Remove(view);
    }
    public float ComputeAverageYaw()
    {
        Vector2 sum = Vector2.zero;
        foreach (AView view in activeViews)
        {
            sum += new Vector2(Mathf.Cos(view.GetConfiguration().yaw * Mathf.Deg2Rad),
            Mathf.Sin(view.GetConfiguration().yaw * Mathf.Deg2Rad)) * view.weight;
        }
        return Vector2.SignedAngle(Vector2.right, sum);
    }
    #endregion

}
