using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox, panelTextOnTrigger;       // Asignas el panel ui aquí
    public TextMeshProUGUI dialogueText; // Asignas TMP Text en el panel
    [TextArea]
    public string message = "Hello, wolrd."; //texto customizable de prueba

    public float typingSpeed = 0.05f;
    private bool isTalking = false;


    private void Start()
    {
        dialogueBox.SetActive(false); // Se asegura de que al principio está escondido
        panelTextOnTrigger.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTalking)
        {
            StartCoroutine(StartDialogue());
            //dialogueBox.SetActive(false);
        }
    }

    private IEnumerator StartDialogue()
    {
        isTalking = true;
        dialogueBox.SetActive(true);
        dialogueText.text = "";
        
        // Pausa el juego
        Time.timeScale = 0f;

      
        foreach (char c in message)
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }

        // Continua cuando el player hace click con el ratón
        yield return new WaitUntil(() => (Input.GetMouseButtonDown(0)));

        // Resume game
        dialogueBox.SetActive(false);
        Time.timeScale = 1f;
        isTalking = false;
    }
}
