using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSaves", menuName = "Scriptable Objects/PlayerSaves")]
public class PlayerSaves : ScriptableObject
{
    [SerializeField] private int currentSlot;

    public void SetCurrentSlot(int slotID)
    {
        currentSlot = slotID;
    }

    public int GetCurrentSlot()
    {
        return currentSlot;
    }
}
