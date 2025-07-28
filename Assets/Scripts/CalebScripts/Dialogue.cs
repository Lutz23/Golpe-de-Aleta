using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private bool isPlayerinRange;
    private GameObject personaje;
    public bool yaHableconPingu = false;

    [SerializeField] private GameObject dialogueMark; //marca de dialogo
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;


    private bool didDialogueStart;
    private int lineIndex;


    [SerializeField] private float typingTime = 0.05f;

    //**musica para el dialogo**//
    AudioManagerScript audioManager;


    void Start()
    {

        personaje = GameObject.FindWithTag("Player");

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }
    void Update()
    {



        if (isPlayerinRange && Input.GetKeyDown(KeyCode.E))
        { //si el personaje está en el rango del trigguer y pulsas f
            if (!didDialogueStart)
            { //y el dialogo no ha empezado
                StartDialogue(); //se abre el panel y se escribe la primera linea
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {//si el ya se ha iniciado, pasa a la sig. linea
                NextDialogueLine();
            }
            else
            {//si no se mostró la linea entera la muestra
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            Debug.Log("he econtrado al player");
            isPlayerinRange = true;
            dialogueMark.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerinRange = false;
            if (dialogueMark != null)
            {
                dialogueMark.SetActive(false);
            }
            Debug.Log("Dejo de ver al player, ya no está en rango");
        }
    }


    private void StartDialogue()
    {
        didDialogueStart = true;
        dialogueText.text = "";
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        StartCoroutine(ShowLine());
        Time.timeScale = 0f;


    }

    private void NextDialogueLine()
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

            yaHableconPingu = true;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_Dialogo);

        foreach (char ch in dialogueLines[lineIndex])
        { //loop, characteres escritos de uno a uno y que tarden un pelin en aparecer
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }

        yield return null;
        
    }
}



