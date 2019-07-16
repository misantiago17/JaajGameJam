using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Toda vez que quiserem adicionar um diálogo novo a um NPC vcs tem que botar esse script no GameObject. Só tem dois requerimentos:
/// 
///-> O GameObject que vc for atrelar esse script tem que ter um ActionTrigger(ou qualquer script filho dele.Ex: Action Grab Object - todo filho de action Trigger tem "Action" na frente). 
///Assim ele vai ativar no novo diálogo no NPC quando triggar a ação dele(Ex: pegou o cartão, adiciona o novo diálogo)
///-> Os NPCs que vcs botarem pra adicionar diálogo precisam ter o componente "Action Dialog".
///
///A ideia é que para cada NPCque for adicionar um novo diálogo, vc adiciona mais um componente do script Dialogue Add New.Ou seja, 
///pode-se ter 30 componentes de Dialogue Add New em um objeto só e cada um deles vai adicionar um diálogo diferente para um NPC diferente.
///
/// </summary>

public class DialogueAddNew: MonoBehaviour
{
    public GameObject NPC;
    public DialoguePrompt[] DialoguePrompts;

}