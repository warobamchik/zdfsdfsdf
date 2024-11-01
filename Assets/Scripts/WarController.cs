using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class WarController : MonoBehaviour
{
    public GameObject player;
    public Transform wizard;
    public GameObject sword;
    public GameObject portal;

    public List<GameObject> enemies = new List<GameObject>();
    public int isWar = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isWar == 0 && sword.activeSelf)
        {
            isWar = 1;
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyController>().player = player;
                enemy.GetComponent<EnemyController>().isAttacking = true;
            }
        }
    }

    public void StartWar()
    {
        player.GetComponent<PlayerController>().isWarrior = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        wizard.DOMoveY(wizard.position.y - 4f, 1f);
        sword.SetActive(true);

        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }

    private void Update()
    {
        if (isWar == 1)
        {
            foreach (GameObject enemy in enemies)
            {
                EnemyController controller = enemy.GetComponent<EnemyController>();
                if (controller.hp <= 0f)
                {
                    enemies.Remove(enemy);
                }
            }
            if (enemies.Count == 0)
            {
                isWar = 2;
            }
        }
        else if (isWar == 2)
        {
            portal.SetActive(true);
            sword.SetActive(false);
        }
    }
}
