using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endpoitn : MonoBehaviour
{
    private AudioSource finishSound;
    private UI_manage uimanger;
    private  bool complete = true;
    [SerializeField] private player_life player;
    void Start()
    {
        finishSound=GetComponent<AudioSource>();
        uimanger = FindObjectOfType<UI_manage>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "player" && complete){
            complete=false;
            finishSound.Play();
            Invoke("CompleteLevel",1f);
            player.stop();
        }
    }

    private void CompleteLevel(){
        uimanger.GameComplete();
    }
}
