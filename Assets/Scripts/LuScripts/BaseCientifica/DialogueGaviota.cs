using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueGaviota : MonoBehaviour
{
    public GameObject dialogueTriggerObject;
    [Header("Dialogue Settings")]
    public TextMeshProUGUI textComponent;
    [TextArea(3, 10)] public string[] lines;
    public float textSpeed = 0.05f;

    [Header("Gameplay Freeze")]
    public MonoBehaviour[] scriptsToDisable; // drag player/enemy movement scripts here

    private int index;

    void Start()
    {
        Time.timeScale = 1f;
        textComponent.text = string.Empty;

        // Freeze game systems
        foreach (var script in scriptsToDisable)
        {
            if (script != null)
                script.enabled = false;
        }

        StartDialogue();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //(Input.GetKeyDown(KeyCode.E)) <No funciona
        {
            if (lines.Length == 0) return;

            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        if (lines == null || lines.Length == 0)
        {
            Debug.LogWarning("No dialogue lines assigned.");
            return;
        }

        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textComponent.text = "";

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed); // unaffected by Time.timeScale
        }
        Debug.Log("Finished TypeLine");
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // Unfreeze game systems
            foreach (var script in scriptsToDisable)
            {
                if (script != null)
                    script.enabled = true;
            }

            GameObject lider = GameObject.FindWithTag("NPCLider");
            if (lider != null)
            {
                lider.SetActive(false);
                Debug.Log("Líder ha desaparecido tras la cutscene.");
            }

            if (GameManager.marcadorFotos >= 4)
            {
                SceneManager.LoadScene("VideoFinal");
                Debug.Log("Cargando escena final porque se alcanzó el valor requerido de creencia.");
            }
            else
            {
                Debug.Log("Diálogo final terminó pero no se alcanzó la creencia mínima.");
            }

            Debug.Log("CutsceneDialogueGaviota is being destroyed after dialogue finishes.");
            Destroy(gameObject); //No funciona, hay que darle click con el mouse


            // gameObject.SetActive(false); // hide dialogue object

            // // remove the leader penguin
            // GameObject lider = GameObject.FindWithTag("NPCLider");
            // if (lider != null)
            // {
            //     lider.SetActive(false);  // Or Destroy(lider);
            //     Debug.Log("Líder ha desaparecido tras la cutscene.");
            // }
            // else
            // {
            //     Debug.LogWarning(" No se encontró el líder con el tag 'NPCLider'.");
            //  }
            //     }

        }
        Debug.Log("Para el commit, irrelevante");
        Debug.Log("Para el commit, irrelevante 02");
    }
}
