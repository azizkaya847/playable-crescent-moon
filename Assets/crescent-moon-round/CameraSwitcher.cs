using UnityEngine;
using Unity.Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Kameralar (Yeni Cinemachine Camera)")]
    public CinemachineCamera fpsCamera;
    public CinemachineCamera tpsCamera;

    [Header("Kontrol Tuşu")]
    public KeyCode switchKey = KeyCode.C; 

    private bool isFpsActive = false;

    void Start()
    {
        ActivateTPS();
    }

    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            if (isFpsActive)
            {
                ActivateTPS();
            }
            else
            {
                ActivateFPS();
            }
        }
    }

    void ActivateFPS()
    {
        fpsCamera.Priority = 15; 
        tpsCamera.Priority = 10;
        isFpsActive = true;
    }

    void ActivateTPS()
    {
        fpsCamera.Priority = 10;
        tpsCamera.Priority = 15; 
        isFpsActive = false;
    }
}