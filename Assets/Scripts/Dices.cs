using UnityEditor.VisionOS;
using UnityEngine;

using NUnit.Framework.Interfaces;

public class Dices : MonoBehaviour
{
    [SerializeField] private int launchDiceQuantity = 1;
    [SerializeField] private int diceMax = 6;
    [SerializeField] private int diceMin = 1;

    [SerializeField] private PlayerMouvements playerMouvements;

    public void LaunchDice()
    {
        int totalResult = 0;
        for (int i = 0; i < launchDiceQuantity; i++)
        {
            int diceResult = RandomDiceResult();
            totalResult += diceResult;
        }
        print(totalResult);

        if(playerMouvements != null)
        {
            playerMouvements.MovePlayer(totalResult);
        }
    }

    public int RandomDiceResult()
    {
        int result = UnityEngine.Random.Range(diceMin, (diceMax + 1));
        return result;
    }
}
