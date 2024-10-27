using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

public class ChairStarter : MonoBehaviour
{
    public GameObject video;
    public Transform teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(VideoPlay(other.gameObject));
        }
    }

    IEnumerator VideoPlay(GameObject player)
    {
        player.transform.position = transform.position + Vector3.up / 2;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        video.SetActive(true);
        video.GetComponent<VideoPlayer>().Play();

        yield return new WaitForSeconds(81f);

        player.transform.LookAt(video.transform.position);
        player.GetComponent<FirstPersonController>().cameraCanMove = false;
        player.transform.DORotate(new Vector3(0f, 0f, -120f), 1f);
        player.transform.DOMove(video.transform.position - new Vector3(0.5f, 0f, 0.4f), 1f);

        yield return new WaitForSeconds(1f);
        player.transform.position = teleportPoint.position;
        player.GetComponent<FirstPersonController>().cameraCanMove = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
}
