using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueNPC : MonoBehaviour
{
    private bool isPlayerinRange;

    [SerializeField] private GameObject dialogueMark;
    [SerializeField, TextArea] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;

    private bool didDialogueStart;
    private int lineIndex;

    [SerializeField] private float typingTime = 0.05f;

    void Start()
    {
        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (isPlayerinRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerinRange = true;
            dialogueMark.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerinRange = false;
            dialogueMark.SetActive(false);
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialogueText.text = ""; // Asegúrate de que empieza vacío
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;

        StopAllCoroutines();
        StartCoroutine(StartTypingWithDelay()); // nuevo método
        Time.timeScale = 0f;
    }

    void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

private IEnumerator ShowLine()
{
    dialogueText.text = string.Empty;

    foreach (char ch in dialogueLines[lineIndex])
    {
        dialogueText.text += ch;
        yield return new WaitForSecondsRealtime(typingTime);
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_Dialogo);
    }
}
    
    private IEnumerator StartTypingWithDelay()
{
    // Esperamos un poco antes de empezar a escribir
    yield return new WaitForSecondsRealtime(0.2f); // puedes subirlo a 0.1f si sigue fallando

    StartCoroutine(ShowLine());
}
}
