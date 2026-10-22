using UnityEngine;

public class PlayerMouvements : MonoBehaviour
{
    [Header("Saves")]
    [SerializeField] private SlotsSaves saveSlots;
    [SerializeField] private PlayerSaves savePlayer;
    
    public void MovePlayer(int diceResult)
    {
        Transform newPos = FindSlotToMove(diceResult);
        if (newPos != null)
        {
            gameObject.transform.position = newPos.position;
        }
    }

    private Transform FindSlotToMove(int diceResult)
    {
        int slot = savePlayer.GetCurrentSlot() + diceResult;
        if(slot > saveSlots.slotsCount)
        {
            slot = saveSlots.slotsCount;
        }
        if(saveSlots.GetSlotFromList(slot) != null)
        {
            savePlayer.SetCurrentSlot(slot);
            return saveSlots.GetSlotFromList(slot).transform;
        }
        return null;
    }
}
