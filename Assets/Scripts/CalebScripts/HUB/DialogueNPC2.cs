using System.Collections;
using UnityEngine;
using TMPro;


public class DialogueNPC2 : MonoBehaviour
{
    private bool isPlayerinRange;
    private GameObject personaje;


    public string[] dialogoInicial;
    public string[] dialogoCon1foto;
    public string[] dialogoCon2foto;
    public string[] dialogoCon3foto;
    public string[] dialogoCon4foto;


    [SerializeField] private GameObject dialogueMark; //marca de dialogo
    //[SerializeField, TextArea(4, 6)] private string[] dialogueLines;
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


        if (isPlayerinRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!didDialogueStart)
            {
                // Selecciona el diálogo según la cantidad de fotos
                if (GameManager.marcadorFotos >= 4)
                {
                    currentLines = dialogoCon4foto;
                }
                else if (GameManager.marcadorFotos == 3)
                {
                    currentLines = dialogoCon3foto;
                }
                else if (GameManager.marcadorFotos == 2)
                {
                    currentLines = dialogoCon2foto;
                }
                else if (GameManager.marcadorFotos == 1)
                {
                    currentLines = dialogoCon1foto;
                }
                else
                {
                    currentLines = dialogoInicial;
                }
                StartDialogue();


                // Movimiento y logs
                if (GameManager.marcadorFotos >= 0)
                {
                    Debug.Log("Dialogonpc con 0 fotos");
                }
                if (GameManager.marcadorFotos >= 1)
                {
                    Debug.Log("Dialogonpc con 1 fotos");
                }
                if (GameManager.marcadorFotos >= 2)
                {
                    Debug.Log("Dialogonpc con 2 fotos");
                }
                if (GameManager.marcadorFotos >= 3)
                {
                    Debug.Log("Dialogonpc con 3 fotos");
                }
                if (GameManager.marcadorFotos >= 4)
                {
                    Debug.Log("Dialogonpc con 4 fotos");
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
        foreach (char ch in currentLines[lineIndex])
        { //loop, characteres escritos de uno a uno y que tarden un pelin en aparecer
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
           // AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_Dialogo);
        }
        yield return null;
    }
}
















