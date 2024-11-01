using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossCOntroller : MonoBehaviour
{
    public WarController warController;
    public GameObject horse;

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
        horse.transform.DOMoveY(horse.transform.position.y - 5f, 1f);
        horse.transform.DOLocalRotate(new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)), 1f);

        yield return new WaitForSeconds(2f);

        Application.Quit();
    }
}
