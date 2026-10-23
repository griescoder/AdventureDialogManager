using System.Collections.Generic;

public class DialogService
{
    private readonly DialogRepository _repository;

    public DialogService()
    {
        _repository = new DialogRepository();
    }

    public List<DialogEntry> GetAllDialogs()
    {
        return _repository.GetAll();
    }

    public void AddDialog(string characterName, string text, string condition)
    {
        DialogEntry entry = new DialogEntry
        {
            CharacterName = characterName,
            Text = text,
            Condition = condition
        };

        _repository.Add(entry);
    }

    public void UpdateDialog(DialogEntry entry)
    {
        _repository.Update(entry);
    } 

    public void DeleteDialog(DialogEntry entry)
    {
        _repository.Delete(entry);
    } 

}