using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContainer : MonoBehaviour
{
    [SerializeField] private ChangeSkinOnPlayer _changeSkinsUI;
    
    public Player[] Players;
    public MegaSlapObject[] MegaSlaps;

    private int SkinID => Singletons.Instance.SaveGameState._playerSkinID;
    private int SlapID => Singletons.Instance.SaveGameState._playerMegaslapSkinID;

    private void Start()
    {
        SetNewPlayer(SkinID);
        SetNewMegaslap(SlapID);
        
        _changeSkinsUI.OnChangeSkin += SetNewPlayer;
    }

    public void SetNewPlayer(int NewID)
    {
        foreach (var player in Players)
            player?.gameObject.SetActive(false);


        Singletons.Instance.GameStateMachine.Player = Players[NewID];
        Players[NewID].gameObject.SetActive(true);
    }

    public void SetNewMegaslap(int NewID)
    {
        Players[SkinID].SetNewMegaSlap(MegaSlaps[NewID]);
    }
    
    private void OnDestroy()
    {
        _changeSkinsUI.OnChangeSkin -= SetNewPlayer;
    }
}
