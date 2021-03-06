﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Player player;
    public QuestGiver questGiver;
    public Dialogue mainDialogue;
    public Dialogue questDialogue;
    public Dialogue conversateDialogue;
    public Dialogue denyQuestDialogue;
    public Dialogue acceptQuestDialogue;
    public Dialogue tooWeakDialogue;

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(mainDialogue,"Ask her about her daughter","Ask about quest");
        DialogueManager.instance.getFirstButton().onClick.RemoveAllListeners();
        DialogueManager.instance.getFirstButton().onClick.AddListener(onClickConversate);
        DialogueManager.instance.getSecondButton().onClick.RemoveAllListeners();
        DialogueManager.instance.getSecondButton().onClick.AddListener(onClickQuest);
    }

    public void onClickQuest()
    {
       DialogueManager.instance.StartDialogue(questDialogue,"Accept","Deny");
       DialogueManager.instance.getFirstButton().onClick.RemoveAllListeners();
       DialogueManager.instance.getFirstButton().onClick.AddListener(onClickAccept);
       DialogueManager.instance.getSecondButton().onClick.RemoveAllListeners();
       DialogueManager.instance.getSecondButton().onClick.AddListener(onClickDeny);
       
    }

    public void onClickConversate()
    {
       DialogueManager.instance.StartDialogue(conversateDialogue,null,null);
    }
    public void onClickAccept()
    {
       if (player.GetComponent<Luck>().curLuck >= 50)
       {
          DialogueManager.instance.StartDialogue(acceptQuestDialogue,null,null);
          questGiver.OpenQuestWindow();
       }
       else
       {
          DialogueManager.instance.StartDialogue(tooWeakDialogue,null,null);
       }
       
       
    }

    public void onClickDeny()
    {
       DialogueManager.instance.StartDialogue(denyQuestDialogue,null,null);
    }
}
