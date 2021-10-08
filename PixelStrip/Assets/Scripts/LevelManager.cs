using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject firstStage;
    [SerializeField] private GameObject secondStage;
    [SerializeField] private GameObject thirdStage;
    [SerializeField] private GameObject fiftyStage;
    private int currentStage;

    public static LevelManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        currentStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void EndStage()
    {
        currentStage++;
        LoadNextStage();
    }

    private void LoadNextStage()
    {
        switch (currentStage)
        {
            case 1:
                firstStage.SetActive(false);
                secondStage.SetActive(true);
                break;
            case 2:
                secondStage.SetActive(false);
                thirdStage.SetActive(true);
                break;
            case 3:
                thirdStage.SetActive(false);
                fiftyStage.SetActive(true);
                break;
            case 4:
                fiftyStage.SetActive(false);
                break;
            case 5:
                break;
            default:
                break;
        }
    }

}
