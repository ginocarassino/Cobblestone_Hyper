using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCollect : MonoBehaviour
{
    public AudioSource BlipSound;

    PlayerController ctr_Player;
    MainController ctr_Main;

    private void Start()
    {
        ctr_Player = (PlayerController)FindObjectOfType(typeof(PlayerController));
        ctr_Main = (MainController)FindObjectOfType(typeof(MainController));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.tag == "SpeedCube")
        {
            if (other.gameObject.tag == "Player")
            {
                ctr_Player.runSpeed -= 2;
                BlipSound.Play(0);
                Destroy(this.gameObject);
            }
        }
        else if (this.tag == "GroundBullet")
        {
            if (other.gameObject.tag == "Player")
            {
                ctr_Main.bulletsNumber++;
                ctr_Main.TBullets.text = ctr_Main.bulletsNumber.ToString();
                Destroy(this.gameObject);
            }
        }
        else if (this.tag == "FloatingCube")
        {
            if (other.gameObject.tag == "Player")
            {
                ctr_Main.nCollectibles++;
                Destroy(this.gameObject);
            }
        }

    }
}
