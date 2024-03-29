using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleThrowing : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    AudioSource audioSource;
    public AudioClip throwing;

    private void Start()
    {
        readyToThrow = true;
        audioSource = GetComponent<AudioSource>();
        print("audio source=" + audioSource);
    }

    private void Throw()
    {

        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    void PlaySoundEffect()
    {
        audioSource.PlayOneShot(throwing);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

}

