using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GuieDialogue : MonoBehaviour
{
   [Header("IconoDialogo")]
	[SerializeField] private GameObject dialogueMark;
	[SerializeField] private GameObject dialoguePanel;
	[SerializeField] private Text dialogueText;
	private float typingTime = 0.05f;
	
	[Header("ArrayDialogos")]
	[SerializeField, TextArea(4,6)] private string[] dialogueLines;
	private bool isPlayerInRange;
	private bool didDialogueStart;
	private int lineIndex;
	
    void Update()
    {
        if(isPlayerInRange && Input.GetButtonDown("Fire1")){
			if(!didDialogueStart)
			{
				StartDialogue();
			}
			else if(dialogueText.text == dialogueLines[lineIndex])
			{
				NextDialogueLine();
			}
		}
    }
	
	private void StartDialogue()
	{
		didDialogueStart = true;
		dialoguePanel.SetActive(true);
		dialogueMark.SetActive(false);
		lineIndex = 0;
		StartCoroutine(ShowLine());
	}
	private void NextDialogueLine()
	{
		lineIndex++;
		if(lineIndex < dialogueLines.Length)
		{
			StartCoroutine(ShowLine());
		}
		else
		{
			didDialogueStart = false;
			dialoguePanel.SetActive(false);
			dialogueMark.SetActive(true);
		}
	}
	/* TIPEO CARACTER POR CARACTER*/
	private IEnumerator ShowLine()
	{
		dialogueText.text = string.Empty;
		
		foreach(char ch in dialogueLines[lineIndex])
		{
			dialogueText.text += ch;
			yield return new WaitForSeconds(typingTime);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			isPlayerInRange = true;
			dialogueMark.SetActive(true);
			Debug.Log("Se puede iniciar dialogo");
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			isPlayerInRange = false;
			dialogueMark.SetActive(false);
			Debug.Log("NO se puede iniciar dialogo");
		}
	}
}
