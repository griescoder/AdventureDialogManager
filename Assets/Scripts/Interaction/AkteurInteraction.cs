
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AkteurInteraction : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogText;

    private DialogService _dialogService;

    private void Awake()
    {
        _dialogService = new DialogService();
    }

    private void OnMouseDown()
    {
        if (dialogPanel == null || dialogText == null)
        {
            Debug.LogWarning("DialogPanel oder DialogText fehlt.");
            return;
        }

        List<DialogEntry> dialogs = _dialogService.GetAllDialogs();

        if (dialogs.Count == 0)
        {
            dialogPanel.SetActive(true);
            dialogText.text = "Akteur: Es sind noch keine Dialoge gespeichert.";
            return;
        }

        DialogEntry entry = dialogs[0];

        dialogText.text = entry.CharacterName + ": " + entry.Text;
        dialogPanel.SetActive(true);
    }
}
