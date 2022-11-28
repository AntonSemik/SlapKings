using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContainer : MonoBehaviour
{
    [SerializeField] private Player[] Players;
    [SerializeField] private MegaSlapObject[] MegaSlaps;

    private int SkinID => Singletons._singletons.SaveGameState._playerSkinID;

    private void Start()
    {
        SetNewPlayer(SkinID);
    }

    public void SetNewPlayer(int NewID)
    {
        Players[0]?.gameObject.SetActive(false);


        Singletons._singletons.GameStateMachine.Player = Players[NewID];
        Players[NewID].gameObject.SetActive(true);
    }

    public void SetNewMegaslap()
    {

    }
}
