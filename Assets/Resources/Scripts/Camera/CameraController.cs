using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    CameraScriptable[] cameraFollowPositions;
    private new Camera camera;
    Transform target;
    public static int currentPosition;
    public static int cameraPositionsArrayLenght;

    private void Start()
    {
        target = SceneData.currentCar.transform;
        camera = Camera.main;
        cameraPositionsArrayLenght = cameraFollowPositions.Length;
    }
    void Update()
    {
        Vector3 wantedPosition;
        if (cameraFollowPositions[currentPosition].followBehind)
            wantedPosition = target.TransformPoint(0, cameraFollowPositions[currentPosition].height, -cameraFollowPositions[currentPosition].distance);
        else
            wantedPosition = target.TransformPoint(0, cameraFollowPositions[currentPosition].height, cameraFollowPositions[currentPosition].distance);

        camera.transform.position = Vector3.Lerp(camera.transform.position, wantedPosition, Time.deltaTime * cameraFollowPositions[currentPosition].damping);

        if (cameraFollowPositions[currentPosition].smoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(target.position - camera.transform.position, target.up);
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, wantedRotation, Time.deltaTime * cameraFollowPositions[currentPosition].rotationDamping);
        }
        else camera.transform.LookAt(target, target.up);
    }
}
