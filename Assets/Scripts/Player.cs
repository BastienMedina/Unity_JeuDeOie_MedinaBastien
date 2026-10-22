using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSaves savePlayer;
    [SerializeField] private SlotsSaves saveSlots;

    void Start()
    {
        InstantiatePlayer();
    }

    public void InstantiatePlayer()
    {
        if (saveSlots.GetSlotFromList(savePlayer.GetCurrentSlot()) != null)
        {
            gameObject.transform.position = saveSlots.GetSlotFromList(savePlayer.GetCurrentSlot()).transform.position;
        }
        else
        {
            Debug.LogWarning("Le slot de départ du player n'a pas été trouvé dans la save");
        }
    }
}
