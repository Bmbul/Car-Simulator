using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsData : MonoBehaviour
{
    public GameObject frontLights;

    public GameObject frontLightsGO;
    public GameObject backLights;
    public Material frontGlowMaterial;
    public Material backGlowMaterial;
    public Material backNormalMaterial;
    public Material frontNormalMaterial;
    public Material brakeMaterial;
    public Material reverseLightMaterial;

    public GameObject brakeGameObject;
    public GameObject reverseDriveLights;
    public Material reverseNormalMaterial;
    bool isLightsOn = false;

    internal void LightsOn()
    {
        frontLights.SetActive(true);
        isLightsOn = true;
        backLights.GetComponent<MeshRenderer>().material = backGlowMaterial;
        frontLightsGO.GetComponent<MeshRenderer>().material = frontGlowMaterial;
        reverseDriveLights.GetComponent<MeshRenderer>().material = backGlowMaterial;
    }

    internal void LightsOff()
    {
        isLightsOn = false;
        frontLights.SetActive(false);
        backLights.GetComponent<MeshRenderer>().material = backNormalMaterial;
        frontLightsGO.GetComponent<MeshRenderer>().material = frontNormalMaterial;
    }

    internal void OnBrake()
    {
        brakeGameObject.GetComponent<MeshRenderer>().material = brakeMaterial;
    }

    internal void OnBrakeRelease()
    {
        if (isLightsOn)
            brakeGameObject.GetComponent<MeshRenderer>().material = backGlowMaterial;
        else
            brakeGameObject.GetComponent<MeshRenderer>().material = backNormalMaterial;
    }

    internal void OnReverseDrive() {
        reverseDriveLights.GetComponent<MeshRenderer>().material = reverseLightMaterial;
    }

    internal void OnReverseDriveRelease()
    {
        if(isLightsOn)
            reverseDriveLights.GetComponent<MeshRenderer>().material = backGlowMaterial;
        else
            reverseDriveLights.GetComponent<MeshRenderer>().material = reverseNormalMaterial;
    }

}
