using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera fpsCamera;
    [SerializeField] private FirstPersonController fpsScript;
    [SerializeField] private float zoomedOutFOV = 30f;
    [SerializeField] private float zoomedInFOV = 10f;

    [SerializeField] private float zoomedOutRotationSpeed = 2f;
    [SerializeField] private float zoomedInRotationSpeed = 0.5f;

    bool zoomedToggle = false;

    private void Start()
    {
        SetFieldOfView(zoomedOutFOV);
        SetRotationSpeed(zoomedOutRotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            zoomedToggle = !zoomedToggle;
            if (zoomedToggle)
            {
                SetFieldOfView(zoomedInFOV);
                SetRotationSpeed(zoomedInRotationSpeed);
            }
            else
            {
                SetFieldOfView(zoomedOutFOV);
                SetRotationSpeed(zoomedOutRotationSpeed);
            }
        }
    }

    void SetFieldOfView(float newFOW)
    {
        fpsCamera.m_Lens.FieldOfView = newFOW;
    }

    void SetRotationSpeed(float newRotationSpeed)
    {
        fpsScript.RotationSpeed = newRotationSpeed;
    }
}
