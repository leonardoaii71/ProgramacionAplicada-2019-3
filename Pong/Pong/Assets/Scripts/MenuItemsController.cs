using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


  public class GameOptions{
        public string name;
        public float volume;
        public int dificultad;
        
        private static GameOptions instance;
        public static GameOptions Instance
        {
            get {
                if(instance == null)
                    instance = new GameOptions();
                return instance; 
            }

            set { 
                instance = value;
            }
        }     
        public override string ToString(){
            return "name " + this.name + "volume " + this.volume + "dificultad " + this.dificultad;
        }

    }


public class MenuItemsController : MonoBehaviour
{
   private static GameObject optionsDialog;
   private GameOptionsLoader optionsLoaderScript;

    private void Awake()
    {
        optionsLoaderScript = GameObject.Find("GameOptionsLoader").GetComponent<GameOptionsLoader>();
        
        if (optionsDialog != null)
            return;

        optionsDialog = GameObject.Find("OptionsDialog");
        optionsDialog.SetActive(false);
    }

    private void OnMouseEnter() {
        if(!optionsDialog.activeSelf)
            gameObject.transform.localScale *= 1.1f;
    }

    private void OnMouseExit() {
        if(!optionsDialog.activeSelf)
            gameObject.transform.localScale /= 1.1f;
    }

    private void OnMouseDown() {
        if (optionsDialog.activeSelf)
            return;
       
        switch(gameObject.name)
        {
            case "Iniciar":
                SceneManager.LoadScene("Taberna");
                break;
            case "Opciones":
                OnMouseExit();
                optionsDialog.SetActive(true);
                UpdateCanvasGUI();
                break;
            case "Salir":
                Application.Quit();
                break;
        }
    }

    public void UpdateCanvasGUI(){
        GameObject.Find("NombreField").GetComponent<UnityEngine.UI.InputField>().text = GameOptions.Instance.name;
        //GameObject.Find("VolumeScroll").GetComponent<UnityEngine.UI.Slider>().value = GameOptions.Instance.volume;
        GameObject.Find("DificultadDrop").GetComponent<UnityEngine.UI.Dropdown>().value = GameOptions.Instance.dificultad;
    }
    
    public void SubmitDialog(){
        PlayerPrefs.SetString("PlayerName", GameOptions.Instance.name);
        PlayerPrefs.Save();
        optionsLoaderScript.SaveGameOptions();
        CancelDialog();
    }
    
    public void CancelDialog()
    {
        optionsDialog.SetActive(false);
    }

    public void NameChanged(InputField inputField){
        GameOptions.Instance.name = inputField.text;
    }

    public void VolumeChanged(UnityEngine.UI.Slider slider){
        GameOptions.Instance.volume = slider.value;
    }

    public void DifficultyChanged(Dropdown dropdown){
        GameOptions.Instance.dificultad = dropdown.value;
    }

}


