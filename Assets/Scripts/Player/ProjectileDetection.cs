using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDetection : MonoBehaviour
{

    public int damage;
    private Rigidbody rb;
    private bool targetHit;
    public GameObject objectToDestroy;

    AudioSource audioSource;
    public AudioClip breaking;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }
    private void OnCollisionEnter(Collision collision) 
    {
        if (targetHit)
            return;
        else 
            targetHit = true;


        // get particle system which is a child of the bottle
        GameObject bottle = transform.GetChild(0).gameObject;
        ParticleSystem ps = bottle.GetComponent<ParticleSystem>();
        ps.Play();
        audioSource.PlayOneShot(breaking);
        //Destroy(gameObject);

        //turn off bottle mesh
        GetComponent<MeshRenderer>().enabled = false;



        if (collision.gameObject.GetComponent<Health>() != null)
        {
            Health enemy = collision.gameObject.GetComponent<Health>();
            enemy.TakeDamage(damage);
            Destroy(objectToDestroy, 3f);
        }


        rb.isKinematic = true;

        transform.SetParent(collision.transform);

    }
}
