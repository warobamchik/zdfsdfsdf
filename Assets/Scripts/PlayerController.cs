using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public Slider hpSlider;
    public GameObject sword;
    public float hp, damage, distance;

    [Space]
    public bool isWarrior = false;
    public static bool isAttacking = false;

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

            if (!isAttacking)
            {
                isAttacking = true;
                Vector3 forwardRotation = new Vector3(0f, -90f, -70f);
                Sequence attackSequence = DOTween.Sequence();

                attackSequence.Append(sword.transform.DOLocalRotate(forwardRotation, 0.3f))
                              .Append(sword.transform.DOLocalRotate(new Vector3(0f, -90f, -12f), 0.3f))
                              .SetAutoKill(false);
                attackSequence.Play();
                isAttacking = false;
            }
        }

        if (hp <= 0f)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
