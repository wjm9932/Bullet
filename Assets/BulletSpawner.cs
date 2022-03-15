using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float spawnTimer = 1f;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        bulletPrefab = Resources.Load("Bullet") as GameObject;
        if(bulletPrefab == null)
        {
            Debug.Log("error");
        }
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0f)
        {
            spawnTimer = 1f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }
}
