using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    float timer = 0;
    [SerializeField] float timeBase = 0.1f;

    [SerializeField] Rigidbody2D Bullet_01;

    [SerializeField] float BulletSpeed;

    [SerializeField] Transform[] FirePoint_Set_One;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            timer += Time.deltaTime;
            if(timer > timeBase)
            {
                SpawnBullets();
                timer = 0;
            }
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            timer = 0;
        }
    }

    void SpawnBullets()
    {
        foreach(var firePoint in FirePoint_Set_One)
        {
            var Instance = Instantiate(Bullet_01, firePoint.position, Quaternion.identity);
            Instance.AddForce(Vector2.right * BulletSpeed);
            Destroy(Instance.gameObject,2);
        }
    }
}
