using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerrespone : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource checkpoint;
    private Transform currentCheckpoint;

    private void Awake()
    {
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
             checkpoint.Play();
            currentCheckpoint = collision.transform;
            collision.GetComponent<Animator>().SetTrigger("start");
        }
    }
}
