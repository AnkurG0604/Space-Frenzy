using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem Explosion;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            var Instance = Instantiate(Explosion, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("sc").GetComponent<PlayerScore>().score += 1;
            Destroy(Instance.gameObject,1);
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Collision");
        }
    }
}
