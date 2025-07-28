using System.Collections;
using UnityEngine;
using TMPro;


public class DialogueLider : MonoBehaviour
{
    private bool isPlayerinRange;
    
    private GameObject personaje;

    public GameObject pinguinoLider;



    //**DESTINOS NPC**//

    //**VARIABLES POR SCRIPT**//
    
    public GameObject pinguNPC2; // NUEVO
    public GameObject pinguNPC3;
    public GameObject pinguNPC4;
    public GameObject pinguNPC5;
    public GameObject pinguNPC6;
    public GameObject pinguNPC7;


    //**DESTINOS PIGNU LIDER**//
  
    public Transform destinoPinguinoLiderInicial; // NUEVO
    


    //**VARIABLES POR SCRIPT**//
    public Transform destinoFinalNPC2; // NUEVO
    public Transform destinoFinalNPC3;
    public Transform destinoFinalNPC4;
    public Transform destinoFinalNPC5;
    public Transform destinoFinalNPC6;
    public Transform destinoFinalNPC7;





    public string[] dialogoInicial;
    public string[] dialogoCon1foto;
    public string[] dialogoCon2foto;
    public string[] dialogoCon3foto;
    public string[] dialogoCon4foto;


    [SerializeField] private GameObject dialogueMark; //marca de dialogo
    //[SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject cutsceneDialogue;




    private bool didDialogueStart;
    private int lineIndex;
    private bool cutsceneTriggered = false;
    private string[] currentLines;




    [SerializeField] private float typingTime = 0.05f;


    //**musica para el dialogo**//
    AudioManagerScript audioManager;
    [SerializeField] private GameObject barraCreencia;


    void Start()
    {
        personaje = GameObject.FindWithTag("Player");
        pinguinoLider = GameObject.FindWithTag("NPCLider");

        barraCreencia = GameObject.Find("barraCreencia");

        destinoPinguinoLiderInicial = GameObject.Find("destinoPinguinoLiderInicial").transform;
        
        if (GameManager.liderYaSeMovio && pinguinoLider != null && destinoPinguinoLiderInicial != null)
        {
            pinguinoLider.transform.position = destinoPinguinoLiderInicial.position;
        }

        //**VARIABLES POR SCRIPT**//
        /* destinoFinalNPC2 = GameObject.Find("destinoPinguinoNPC2").transform;
         destinoFinalNPC3 = GameObject.Find("destinoPinguinoNPC3").transform;
         destinoFinalNPC4 = GameObject.Find("destinoPinguinoNPC4").transform;
         destinoFinalNPC5 = GameObject.Find("destinoPinguinoNPC5").transform;
         destinoFinalNPC6 = GameObject.Find("destinoPinguinoNPC6").transform;
         destinoFinalNPC7 = GameObject.Find("destinoPinguinoNPC7").transform; */

        // if (GameManager.haJugadoMinijuegoBuceo)
        // {
        //     MoverLiderADestinoInicial();
        // }

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }

    void Update()
    {


        // if (Input.GetKeyDown(KeyCode.U))
        // {
        //     GameManager.marcadorFotos += 1;
        //     Debug.Log("Fotos actuales: " + GameManager.marcadorFotos);


        //     barraCreencia.GetComponent<BarraCreencia>().ActualizarBarra();
        // }




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
                    Debug.Log("Líder se mueve cerca de la escena peces");
                }
                if (GameManager.marcadorFotos >= 1)
                {
                    Debug.Log("Barra de creencia aumenta, tienes 1 foto");
                }
                if (GameManager.marcadorFotos >= 2)
                {
                    Debug.Log("Barra de creencia aumenta, tienes 2 fotos");
                }
                if (GameManager.marcadorFotos >= 3)
                {
                    Debug.Log("Barra de creencia aumenta, tienes 3 fotos");
                }
                //if (GameManager.marcadorFotos >= 4)
               // {
                    // // cutsceneTriggered = true;
                    // // Debug.Log("Has conseguido que la colonia crea en ti");
                    // Debug.Log("Moving all NPCs to their final destinations...");
                    // if (pinguNPC2 != null) pinguNPC2.transform.position = destinoFinalNPC2.position;
                    // else Debug.LogWarning("pinguNPC2 not assigned!");

                    // //**VARIABLES POR SCRIPT**// //NUEVO
                    // pinguNPC2.transform.position = destinoFinalNPC2.position;
                    // pinguNPC3.transform.position = destinoFinalNPC3.position;
                    // pinguNPC4.transform.position = destinoFinalNPC4.position;
                    // pinguNPC5.transform.position = destinoFinalNPC5.position;
                    // pinguNPC6.transform.position = destinoFinalNPC6.position;
                    // pinguNPC7.transform.position = destinoFinalNPC7.position;

                    // GameObject cutsceneDialogue = GameObject.Find("CutsceneDialogueGaviota");
                    // if (cutsceneDialogue != null)
                    //     cutsceneDialogue.SetActive(true);
                    // StartCoroutine(RemoveLiderAfterDialogue());
               // }
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

            // ✅ Mover al pingüino cuando el diálogo termina Y solo si tiene 0 fotos
            if (GameManager.marcadorFotos == 0 &&
                pinguinoLider != null &&
                destinoPinguinoLiderInicial != null)
            {
                pinguinoLider.transform.position = destinoPinguinoLiderInicial.position;
                GameManager.liderYaSeMovio = true; 
                Debug.Log("Líder se movió a destinoPinguinoLiderInicial después de terminar el diálogo.");
            }
        }
        if (GameManager.marcadorFotos >= 4 && !cutsceneTriggered)
        {
            cutsceneTriggered = true;

            // Move all NPCs
            if (pinguNPC2 != null) pinguNPC2.transform.position = destinoFinalNPC2.position;
            if (pinguNPC3 != null) pinguNPC3.transform.position = destinoFinalNPC3.position;
            if (pinguNPC4 != null) pinguNPC4.transform.position = destinoFinalNPC4.position;
            if (pinguNPC5 != null) pinguNPC5.transform.position = destinoFinalNPC5.position;
            if (pinguNPC6 != null) pinguNPC6.transform.position = destinoFinalNPC6.position;
            if (pinguNPC7 != null) pinguNPC7.transform.position = destinoFinalNPC7.position;

            // Trigger cutscene dialogue GameObject
            // GameObject cutsceneDialogue = GameObject.Find("CutsceneDialogueGaviota");
            // if (cutsceneDialogue != null)
            // {
            //     cutsceneDialogue.SetActive(true);
            // }
            // else
            // {
            //     Debug.LogWarning("CutsceneDialogueGaviota not assigned in the inspector.");
            // }

           
           

             if (cutsceneDialogue != null)
             {
                 cutsceneDialogue.SetActive(true);
             }
             else
             {
                Debug.LogWarning("CutsceneDialogueGaviota not assigned in the inspector.");
             }
        }

    }


    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in currentLines[lineIndex])

        { //loop, characteres escritos de uno a uno y que tarden un pelin en aparecer
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);


            AudioManagerScript.Instance.SuenaClip(AudioManagerScript.Instance.s_Dialogo);


        }
        Debug.Log("Finished TypeLine");
    }


    // public void MoverLiderADestinoInicial()
    // {
    //     if (pinguinoLider != null && destinoPinguinoLiderInicial != null)
    //     {
    //         pinguinoLider.transform.position = destinoPinguinoLiderInicial.position;
    //         Debug.Log("Líder volvió a destino inicial");
    //     }
    // }

private IEnumerator RemoveLiderAfterDialogue()
{
    yield return new WaitForSecondsRealtime(0.5f); // Short delay (optional)

    GameObject lider = GameObject.FindWithTag("NPCLider");
    if (lider != null)
    {
        lider.SetActive(false); // Or Destroy(lider);
        Debug.Log("Líder ha desaparecido tras el diálogo final.");
    }
}

}
















