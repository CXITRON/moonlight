using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings.Switch;

public class ScriptManager : MonoBehaviour
{
    public Dictionary<string, string> scripts = new Dictionary<string, string>();
    // Start is called before the first frame update
    void Start()
    {
        
        
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            scripts = ScriptLoader("Languages/ko-kr");
        }
    }

    Dictionary<string,string> ScriptLoader(string filePath)
    {
        Dictionary<string, string> scripts_dict = new Dictionary<string, string>();

        TextAsset scriptsAsset = Resources.Load<TextAsset>(filePath);
        string scripts = scriptsAsset.text;

        string[] script_splited = scripts.Split('\n');

        for (int i = 0; i < script_splited.Length; i++)
        {
            if(script_splited[i].Length != 0){
                if (script_splited[i][0] != '#' && script_splited[i].Contains(':'))
                {
                    if (script_splited[i].Contains("\t"))
                    {
                        script_splited[i] = script_splited[i].Replace("\t", "");
                    }
                    scripts_dict.Add(script_splited[i].Split(": ")[0], script_splited[i].Split(": ")[1]);
                }
            }
            
            

        }
        Debug.Log("====Script Loaded====");
        foreach (KeyValuePair<string, string> entry in scripts_dict)
        {

            Debug.Log($"\nKey: {entry.Key} / Value: {entry.Value}");
        }

        return scripts_dict;
    }
}
