using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    private MainController Main_CTR;

    public Transform spawnPoint;
    public GameObject bullet;
    public float speed = 5f;

    void Start()
    {
        Main_CTR = (MainController)FindObjectOfType(typeof(MainController));
    }

    void Update()
    {
        if (Main_CTR.bulletsNumber >= 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Main_CTR.bulletsNumber--;
                Main_CTR.TBullets.text = Main_CTR.bulletsNumber.ToString();
                ShootBullet();
            }
        }
    }

    private void ShootBullet()
    {
        GameObject bull = Instantiate(bullet, spawnPoint.position, bullet.transform.rotation);
        Rigidbody rig = bull.GetComponent<Rigidbody>();

        rig.AddForce(spawnPoint.right*speed, ForceMode.Impulse);
    }
}
