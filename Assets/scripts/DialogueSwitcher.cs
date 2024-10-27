using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueSwitcher : MonoBehaviour
    {
        [SerializeField] private string[] _disableTags;
        private DialogueStory _dialogueStory;

        private void Start()
        {
            _dialogueStory = FindObjectOfType<DialogueStory>(true);
            _dialogueStory.ChangedStory += Disable;
        }

        private async void Disable(DialogueStory.Story story)
        {
            if (_disableTags.All(disableTag => story.Tag != disableTag)) return;
            await Task.Delay(1000);
            _dialogueStory.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void OnTriggerEnter(Collider other)
        {
            _dialogueStory.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}