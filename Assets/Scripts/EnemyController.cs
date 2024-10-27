using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;

    [Space]
    public bool isAttacking = false;
    public float speed, hp, damage;

    private float afterAttackTimer;

    private void LateUpdate()
    {
        afterAttackTimer += Time.deltaTime;
        if (isAttacking)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), Time.deltaTime * speed);

            if (hp <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && afterAttackTimer >= 1f)
        {
            afterAttackTimer = 0f;
            other.GetComponent<PlayerController>().hp -= damage;
        }
    }
}
