using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public string currentRod;
    private RodStatus currentRodStatus;

    public Canvas RodChoice;
    public Button RodChoice01;
    public Button RodChoice02;
    
    public DataManager dataManager;
    // invetory will carry over
    public List<string> Inventory = new List<string>();
    // if fish added to inventory, set to true and update to log book. if fish remove no need to check
    public bool addedFishToInventory = false;
    

    public static Player Instance { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentRod = "R01";
        currentRodStatus = dataManager.RodDataByID(currentRod);
        Debug.Log(currentRod);
        Debug.Log(dataManager.RodDataByID(currentRod).rodName);

        SceneManager.activeSceneChanged += ChangedActiveScene;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(addedFishToInventory);
        //if player catches fish, invetory.Add(fishID);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Inventory.Add("F01");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Inventory.Add("F02");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Inventory.Add("F03");
        }

    }

    public void FishCaughtAndAddIntoInventory(string FishID)
    {
        Inventory.Add(FishID);
        addedFishToInventory = true;
        Debug.Log("I caught " + FishID);
    }

    public void DisplayRodChoices()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            //showing player the chocies
            RodChoice.gameObject.SetActive(true);
        }
    }

    public void ChooseR02()
    {
        currentRod = "R02";
        currentRodStatus = dataManager.RodDataByID(currentRod);
        if (gameObject.GetComponentInChildren<LineRenderer>().name == "Rod")
        {
            gameObject.GetComponentInChildren<LineRenderer>().startColor = new Color(0.254902f, 0.4196078f, 0.02745098f);
            gameObject.GetComponentInChildren<LineRenderer>().endColor = new Color(0.254902f, 0.4196078f, 0.02745098f);
        }
        Debug.Log(currentRod + " " + currentRodStatus.rodName);
        RodChoice.gameObject.SetActive(false);
    }
    public void ChooseR03()
    {
        currentRod = "R03";
        currentRodStatus = dataManager.RodDataByID(currentRod);
        if (gameObject.GetComponentInChildren<LineRenderer>().name == "Rod")
        {
            gameObject.GetComponentInChildren<LineRenderer>().startColor = new Color(0.627451f, 0.3647059f, 0.1647059f);
            gameObject.GetComponentInChildren<LineRenderer>().endColor = new Color(0.627451f, 0.3647059f, 0.1647059f);
        }
        Debug.Log(currentRod + " " + currentRodStatus.rodName);
        RodChoice.gameObject.SetActive(false);
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }

        DisplayRodChoices();
    }

}
