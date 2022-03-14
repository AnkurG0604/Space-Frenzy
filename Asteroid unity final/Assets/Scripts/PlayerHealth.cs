using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int Lives = 3;

    [SerializeField] Text lives;

    [SerializeField] ParticleSystem explosion;

    void Update()
    {
        lives.text = Lives.ToString();

        if(Lives == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Lives -= 1;
            var ins = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(ins.gameObject,1);
            Destroy(other.gameObject);
        }
    }
}
