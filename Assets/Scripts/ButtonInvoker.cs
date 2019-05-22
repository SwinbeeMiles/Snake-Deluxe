using UnityEngine;
 using UnityEngine.UI;
 
 [RequireComponent(typeof(Button))]
 public class ButtonInvoker : MonoBehaviour {
 
     public KeyCode key;
 
     public Button button {get; private set;}
 
     void Awake() {
         button = GetComponent<Button>();
     }
 
     // Update is called once per frame
     void Update () {
         if (Input.GetKeyDown(key)) {
             Down();
         }
     }

     void Down() {
         button.onClick.Invoke();
     }
 }
