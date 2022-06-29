using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewMaterial : MonoBehaviour {

    Material[] MyMat;
    public GameObject[] MyFlags;
    GameObject importFlag;
    GameObject[] importFlags;
    Material[] myNewMat;

    SymbolController objeto;

    //Texture importText;
    //Color importColor;




    // Use this for initialization
    void Awake()
    {
        


    }
	
	// Update is called once per frame
	void Update () {
		
	}
    

    public void CreateMat()
    {
        importFlags = GetComponent<SymbolController>().GameObj;
        importFlag = importFlags[0];

       


        MyMat = importFlag.GetComponent<SkinnedMeshRenderer>().materials;
        
           
        for (int i = 0;  MyFlags.Length > i; i++)
        {
                       

            MyFlags[i].GetComponent<SkinnedMeshRenderer>().materials = MyMat;

        }

        }  
    }

