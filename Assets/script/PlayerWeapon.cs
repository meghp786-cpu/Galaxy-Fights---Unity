using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] ParticleSystem[] Lasers;
    [SerializeField] RectTransform crosshair; 
    [SerializeField] Transform trackingTarget;
    [SerializeField] float targetDistance = 250f;

    bool isFiring = false;
    private void Start()
    {
        Cursor.visible = false;
    }

    private void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void Update()
    {
        ProcessFire();
        TrakingMouse();
        TrackTarget();
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        foreach (ParticleSystem Laser in Lasers)
        {
            Vector3 dir = trackingTarget.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Laser.transform.rotation = lookRotation;
        }
    }

    private void TrackTarget()
    {
        Vector3 targetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        trackingTarget.position = Camera.main.ScreenToWorldPoint(targetPosition);
    }

    private void TrakingMouse()
    {
        crosshair.position = Input.mousePosition;
    }

    private void ProcessFire()
    {
        
        foreach(ParticleSystem Laser in Lasers)
        {
            var emissionModule = Laser.emission;
            emissionModule.enabled = isFiring;
        }
    }
}
