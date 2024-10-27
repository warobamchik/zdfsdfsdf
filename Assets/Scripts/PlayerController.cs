using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float hp, damage, distance;

    [Space]
    public bool isWarrior = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isWarrior)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    hit.transform.GetComponent<EnemyController>().hp -= damage;
                }
            }
        }

        if (hp <= 0f)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
