using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cherrydev;

public class DialogColliderStarter : MonoBehaviour
{
    public DialogBehaviour dialogBehaviour;
    public DialogNodeGraph dialogGraph;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            dialogBehaviour.StartDialog(dialogGraph);
        }
    }
}
