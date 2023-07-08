using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_life : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private UI_manage uimanger;
    [SerializeField] private AudioSource DeathSound;

    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }


    private void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        uimanger = FindObjectOfType<UI_manage>();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Trap")){
            TakeDamage(1f);
        }
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            anim.SetTrigger("death");
            DeathSound.Play();
            stop();
        }
    }


    private void RestartLevel(){
        uimanger.GameOver();
    }
    public void stop(){
        rb.bodyType = RigidbodyType2D.Static;
    }
}
