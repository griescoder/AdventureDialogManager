
using UnityEngine;

public class TravelerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;

    private void OnMouseDown()
    {
        if (dialogPanel != null)
        {
            dialogPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("DialogPanel wurde nicht zugewiesen.");
        }
    }
}
