using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionNotes : MonoBehaviour
{
    public ParticleSystem Circle;
    public GameObject Note;
    public AudioSource NoteSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collision");

            Destroy(Note.gameObject);
            Circle.Play();
            NoteSound.Play(0);
            
            StartCoroutine(Counter());
        }
    }


    IEnumerator Counter()
    {
        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
    }
}
