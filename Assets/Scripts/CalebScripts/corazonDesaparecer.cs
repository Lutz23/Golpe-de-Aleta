// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class corazonDesaparecer : MonoBehaviour
// {
//     public static int vidas = 3;
//      private GameObject cora1;
//      private GameObject cora2;
//      private GameObject cora3;

//     // Start is called before the first frame update
//     void Start()
//     {
    
//          cora1 = GameObject.Find("cora1");
//          cora2 = GameObject.Find("cora2");
//          cora3 = GameObject.Find("cora3");
//     }


//     // Update is called once per frame
//     void Update()
//     {
        
//         if (vidas <=2)
//         {
//             Debug.Log("tengo 2 vidas y elimino corazon1");
//             Destroy(cora1);
//         }

//         if (vidas <= 1)
//         {

//             Debug.Log("tengo 1 vidas loool");
//                Destroy(cora2);
//         }


//         if (vidas <= 0)
//         {
//             Destroy(cora3);
//             SceneManager.LoadScene("Lobby");
//             //respawn

//         }
//     }



// }
