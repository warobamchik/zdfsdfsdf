using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossCOntroller : MonoBehaviour
{
    public WarController warController;
    public GameObject horse;
    public GameObject portal;

    public int hp;

    private void Start()
    {
        warController.isWar = 1;
        warController.StartWar();
    }

    public void A()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Damage()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        hp--;
        if (hp <= 0)
        {
            StartCoroutine(Win());
        }
    }

    IEnumerator Win()
    {
        horse.transform.DOMoveY(horse.transform.position.y - 15f, 2f);
        horse.transform.DOLocalRotate(new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)), 2f);

        yield return new WaitForSeconds(3f);

        portal.SetActive(true);
    }
}
