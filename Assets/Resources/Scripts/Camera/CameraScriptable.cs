using UnityEngine;

[CreateAssetMenu(fileName = "NewCameraPosition", menuName = "ScriptableObjects/CreateNewCameraPosition")]
public class CameraScriptable : ScriptableObject
{
    public float distance = 3.0f;
    public float height = 3.0f;
    public float damping = 5.0f;
    public bool smoothRotation = true;
    public bool followBehind = true;
    public float rotationDamping = 10.0f;

}