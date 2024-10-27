using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChairStarter : MonoBehaviour
{
    public GameObject video;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<FirstPersonController>().playerCanMove = false;
            other.GetComponent<FirstPersonController>().enableHeadBob = false;
            other.transform.position = transform.position + Vector3.up;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            video.SetActive(true);
            video.GetComponent<VideoPlayer>().Play();
        }
    }
}
