
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class DialogManagerUI : MonoBehaviour
{
    public InputField characterNameInput;
    public InputField dialogTextInput;
    public InputField conditionInput;
    public Text dialogListText;

    public InputField dialogIdInput;

    private DialogService _dialogService;

    private void Start()
    
    {
        _dialogService = new DialogService();
        RefreshDialogs();

        Debug.Log("Charakter interactable: " + characterNameInput.interactable);
        Debug.Log("Dialog interactable: " + dialogTextInput.interactable);
        Debug.Log("Bedingung interactable: " + conditionInput.interactable);
        Debug.Log("Dialog-ID interactable: " + dialogIdInput.interactable);
    }

    public void AddDialog()
    {

        if (string.IsNullOrWhiteSpace(characterNameInput.text))
        {
            Debug.LogWarning("Bitte einen Charakternamen eingeben.");
            return;
        }

        if (string.IsNullOrWhiteSpace(dialogTextInput.text))
        {
            Debug.LogWarning("Bitte einen Dialogtext eingeben.");
            return;
        }

        _dialogService.AddDialog(
            characterNameInput.text,
            dialogTextInput.text,
            conditionInput.text
        );

        ClearInputs();
        RefreshDialogs();

        Debug.Log("Dialog wurde hinzugefügt.");
    }

    public void UpdateDialog()
    {
       if (string.IsNullOrWhiteSpace(characterNameInput.text))
        {
            Debug.LogWarning("Bitte einen Charakternamen eingeben.");
            return;
        } 

       if (string.IsNullOrWhiteSpace(dialogTextInput.text))
        {
            Debug.LogWarning("Bitte einen Dialogtext eingeben.");
            return;
        }
       Debug.Log("Dialog-ID-Feld: " + dialogIdInput.name);
       Debug.Log("Dialog-ID-Inhalt: [" + dialogIdInput.text + "]");
       if (!int.TryParse(dialogIdInput.text, out int dialogId))
        {
            Debug.LogWarning("Bitte eine gültige Dialog-ID eingeben. ");
            return;
        }

        var dialogs = _dialogService.GetAllDialogs();
        DialogEntry entry = dialogs.Find(d => d.Id == dialogId);

        if (entry == null)
        {
            Debug.LogWarning("Kein Dialog mit dieser ID gefunden. ");
            return;
        }

        entry.CharacterName = characterNameInput.text;
        entry.Text = dialogTextInput.text;
        entry.Condition = conditionInput.text;

        _dialogService.UpdateDialog(entry);

        RefreshDialogs();
        Debug.Log("Dialog wurde aktualisiert.");
        ClearInputs();
    }

    public void DeleteDialog()
    {
        if (!int.TryParse(dialogIdInput.text, out int dialogId))
        {
            Debug.LogWarning("Bitte eine gültige Dialog-ID eingeben.");
            return;
        }

        var dialogs = _dialogService.GetAllDialogs();
        DialogEntry entry = dialogs.Find(d => d.Id == dialogId);

        if (entry == null)
        {
            Debug.LogWarning("Kein Dialog mit dieser ID gefunden.");
            return;
        }

        _dialogService.DeleteDialog(entry);

        RefreshDialogs();
        ClearInputs();

        Debug.Log("Dialog wurde gelöscht.");

    }

    public void RefreshDialogs()
    {
        var dialogs = _dialogService.GetAllDialogs();
        
        StringBuilder builder = new StringBuilder();

        builder.AppendLine("Gespeicherte Dialoge:");

        foreach (DialogEntry entry in dialogs)
        {
            builder.AppendLine(
                entry.Id + " - " +
                entry.CharacterName + ": " +
                entry.Text
            );

            builder.AppendLine("Bedingung: " + entry.Condition);
            builder.AppendLine();
        }

        dialogListText.text = builder.ToString();
    }

    private void ClearInputs()
    {
        characterNameInput.text = "";
        dialogTextInput.text = "";
        conditionInput.text = "";
    }
}
