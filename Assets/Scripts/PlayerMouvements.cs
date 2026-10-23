using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMouvements : MonoBehaviour
{
    [Header("Saves")]
    [SerializeField] private SlotsSaves saveSlots;
    [SerializeField] private PlayerSaves savePlayer;
    
    [Header("Mouvement parameter")]
    [SerializeField] private float moveSpeed = 0.3f;

    private bool onMove = false;

    public void MovePlayer(int diceResult)
    {
        if (!onMove)
        {
            onMove = true;
            StartCoroutine(MoveSlotAnim(diceResult));
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

    private IEnumerator MoveSlotAnim(int slotQ)
    {
        for(int i = 0; i < slotQ; i++)
        {
            Transform newPos = FindSlotToMove(1);
            if (newPos != null)
            {
                gameObject.transform.position = newPos.position;
            }
            yield return new WaitForSeconds(moveSpeed);
        }
        saveSlots.GetSlotFromList(savePlayer.GetCurrentSlot()).GetComponent<Slot>().ApplySlotEffect();
        onMove = false;
    }
}
