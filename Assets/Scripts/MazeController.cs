using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    public int counter;
    public TextMeshProUGUI text;

    public void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Increment()
    {
        counter++;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (counter == 4)
        {
            text.text = "Дверь открылась!";
            gameObject.SetActive(false);
        }
    }
}
