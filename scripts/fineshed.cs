using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fineshed : MonoBehaviour
{
    private AudioSource finishSound;
    private  bool complete = true;
    void Start()
    {
        finishSound=GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "player" && complete){
            complete=false;
            finishSound.Play();
            Invoke("CompleteLevel",1f);
        }
    }

    private void CompleteLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
