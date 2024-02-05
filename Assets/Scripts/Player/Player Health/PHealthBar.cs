using PlayerHealthB;
using PlayerMov;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PHealthBar : MonoBehaviour
{
    Animator anim;

    [SerializeField] public float maxHealth;
    public float health;
    bool deathSceneStarted;

    public PlayerHealth Playerhealth;
    private void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
        Playerhealth.SetSliderMax(maxHealth);
        deathSceneStarted = false;

    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        Playerhealth.SetSlider(health);
    }
    public void Healing()
    {
        health += 30f;
        Playerhealth.SetSlider(health);
        anim.SetTrigger("drink");
    }
    private void Update()
    {
        if(health > 100f)
        {
            health = 100f;

        }
        if( deathSceneStarted)
        {
            return;
        }
        if (Input.GetKeyDown("q"))
        {
            TakeDamage(20f);
        }
        if (Input.GetKeyDown("e"))
        {
            Invoke("Healing" , 0.01f);
        }
        if (health <= 0)
        {
            anim.SetTrigger("die");
            FindObjectOfType<audioManager>().Play("male_hurt7-48124");
            Invoke("DoAction", 2.0f);
            deathSceneStarted = true;
        }

    }

    void DoAction()
    {
        SceneManager.LoadScene(2);
    }

}
