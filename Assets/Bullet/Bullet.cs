using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.forward * speed;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") == true)
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player") == true)
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetDie();
            }
        }
    }
}


