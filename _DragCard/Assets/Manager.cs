using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct DATA
{

public string[] Data;
}

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Action DropCard;
    public GameObject Card;
    public GameObject DropPanel;
    public GameObject TableTop;
    public Button NextButton;

    public List<DATA>datas;

    private int SceneCount;
    [SerializeField] private PopupPanel popup;
    StringBuilder str = new StringBuilder();
    void Start()
    {



       SceneCount = -1;
        NextButton.onClick.AddListener(NextList);
     
        NextList();
        popup.gameObject.SetActive(false);
    }


    private void NextList()
    {
        NextButton.gameObject.SetActive(false);
        DeletChild(DropPanel.transform);
      



        SceneCount++;
        if (SceneCount == datas.Count) 
        {
            DisplayMsg();
        
            return; 
        }

        for (int i = 0; i < datas[SceneCount].Data.Length; i++)
        {
            GameObject g = Instantiate(Card);

            g.transform.SetParent(TableTop.transform, false);
          
            g.transform.GetChild(1).GetComponent<Text>().text = datas[SceneCount].Data[i].ToString();
            g.gameObject.name = datas[SceneCount].Data[i].ToString();
        }
        Array.Sort(datas[SceneCount].Data);

    }

    
    

    private void OnEnable()
    {
        DropCard += checkSlot;
    }

    private void OnDisable()
    {
        DropCard -= checkSlot;
    }

    private void checkSlot()
    {
        if (DropPanel.transform.childCount == 8)
        {
            NextButton.gameObject.SetActive(true);
        }
        else
        {
            NextButton.gameObject.SetActive(false);
        }
    }
    private void DeletChild(Transform parent)
    {

        if (parent.transform.childCount == 0)
            return;
        bool b = false;
        
        for (int i = 0; i < parent.childCount; i++)
        {
            GameObject g=(parent.transform.GetChild(i).gameObject);
            if(g.name!= datas[SceneCount].Data[i])
            {
                b = true;
            }
             Destroy(g);
          //  print(g.name);
        }
        if(b)
        {
            str.Append((SceneCount+1)+" ");
        }

        print(parent.childCount);


    }
    private void DisplayMsg()
    {

        popup.gameObject.SetActive(true);
        if (str.Length!=0)
        {
            popup.MsgBox("Quation Number "+str + " are Wrong");
        }
        else
        {
            popup.MsgBox("All quations Completed sucessfully");
        }

    }
}
