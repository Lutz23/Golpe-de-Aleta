using System.Collections;
using UnityEngine;
using TMPro;


public class DialoguePinguPez : MonoBehaviour
{
    private bool isPlayerinRange;
    private GameObject personaje;


    public GameObject pinguino1;
    public Transform destinoPinguino1;
    public GameObject pinguino2;
    public Transform destinoPinguino2;
    //public Transform destinoPinguino3;
    public string[] dialogoInicial;
    public string[] dialogoCon20Peces;


    [SerializeField] private GameObject dialogueMark; //marca de dialogo
    //[SerializeField, TextArea(4,6)] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;




    private bool didDialogueStart;
    private int lineIndex;
    private string[] currentLines;


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
        if (Input.GetKeyDown(KeyCode.U))
        {
            GameManager.marcadorPeces = 32;
            Debug.Log("GameManager.marcadorPeces = 32;");
        }



        if (isPlayerinRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!didDialogueStart)
            {
                // Seleccionamos el diálogo según el
                currentLines = GameManager.marcadorPeces >= 20 ? dialogoCon20Peces : dialogoInicial;
                StartDialogue();


                // Si tienes suficientes peces, los pingüinos se mueven
                if (GameManager.marcadorPeces >= 20)
                {
                    GameManager.marcadorPeces -= 20;
                    pinguino1.transform.position = destinoPinguino1.position;
                    pinguino2.transform.position = destinoPinguino2.position;


                    Debug.Log("Pingüinos se mueven y te dejan pasar");
                }
            }
            else if (dialogueText.text == currentLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = currentLines[lineIndex];
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Algo ha entrado al trigger: " + col.name);
        if (col.CompareTag("Player"))
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
        Debug.Log("Iniciando diálogo...");
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;

        if (currentLines == null || currentLines.Length == 0)
        {
            Debug.LogWarning("currentLines está vacío o no inicializado.");
            return;
        }

        StopAllCoroutines();


        StartCoroutine(ShowLine());
        Time.timeScale = 0f;


    }


    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < currentLines.Length)
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

        yield return null;

        if (currentLines == null || currentLines.Length <= lineIndex)
        {
            Debug.LogError("No hay línea válida para mostrar.");
            yield break;
        }

        Debug.Log("Mostrando línea: " + currentLines[lineIndex]);

        foreach (char ch in currentLines[lineIndex])
        { //loop, characteres escritos de uno a uno y que tarden un pelin en aparecer
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);

            AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_Dialogo);


        }
    }







}









