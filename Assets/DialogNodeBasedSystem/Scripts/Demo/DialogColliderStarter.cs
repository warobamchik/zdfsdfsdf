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
            dialogBehaviour.StartDialog(dialogGraph);
        }
    }
}
