using UnityEditor;
using UnityEngine;
using System.Collections;

public class MyWindow : EditorWindow
{
    public GameObject myManager;
    public Canvas myCanvas;
    public Vector3 spawnPoint;
    GameObject flagManager;
    string alertOne = "";
    string alertTwo = "";
    



    // Add menu named "My Window" to the Window menu
    [MenuItem("UltraMare/Flag System/Setup Scene")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        MyWindow window = (MyWindow)EditorWindow.GetWindow(typeof(MyWindow));
        window.minSize = new Vector2(450, 500);
        window.maxSize = new Vector2(450, 500);

        Texture icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/UltraMare/Editor/Flags/recursos/LogoSmall.png");
        GUIContent titleContent = new GUIContent("Flag Wizard", icon);
        window.titleContent = titleContent;        
        window.Show();       
    }


    [MenuItem("UltraMare/Support/Website")]
    private static void NewNestedOption()
    {
        Application.OpenURL("http://www.ultramare.xyz/");
    }

    void OnGUI()
    {        
        GUI.BeginGroup(new Rect(10, 10, 600, 500));
        GUILayout.Space(5);
        EditorGUILayout.BeginVertical(GUILayout.Width(400), GUILayout.Height(0));

        //GUILayout.FlexibleSpace();
        EditorGUILayout.HelpBox("Welcome to the Setup Scene Window \n \n Please follow the instructions:", MessageType.None, true);

        EditorGUILayout.EndVertical();
        GUI.EndGroup();

        GUI.BeginGroup(new Rect(10, 10, 600, 500));
        GUILayout.Space(5);
        EditorGUILayout.BeginVertical(GUILayout.Width(400), GUILayout.Height(0));

        EditorGUILayout.HelpBox("Setup the complete [SceneManager] object with canvas model and all scripts setup.", MessageType.Info, true);

        spawnPoint = (Vector3)EditorGUILayout.Vector3Field("Position in terrain", spawnPoint);

        if (GUILayout.Button("Import Complete Flag Manager", GUILayout.Width(200), GUILayout.Height(25)))
        {

            flagManager = (GameObject)PrefabUtility.InstantiatePrefab(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/UltraMare/Editor/Flags/recursos/[SceneManager].prefab"));
            flagManager.transform.position = spawnPoint;
            
            //flagManager.name = "[Scene Manager]";

        }

        EditorGUILayout.EndVertical();

        GUILayout.Space(5);
        EditorGUILayout.LabelField(" or ", EditorStyles.boldLabel, GUILayout.Width(30));
        GUILayout.Space(5);

        GUI.EndGroup();

        // Part 1 msg
        GUI.BeginGroup(new Rect(10, 10, 600, 500));
        GUILayout.Space(20);
        EditorGUILayout.BeginVertical(GUILayout.Width(400), GUILayout.Height(0));

        //GUILayout.FlexibleSpace();
        EditorGUILayout.HelpBox("1º Step \n \n Please select the object in hierarchy that you want to use as your a Scene Manager to hold important scripts.", MessageType.Info, true);

        EditorGUILayout.EndVertical();
        GUI.EndGroup();


        // Begin Group 2
        GUI.BeginGroup(new Rect(10, 10, 600, 500));
        EditorGUILayout.BeginHorizontal(GUILayout.Width(400));

        EditorGUILayout.LabelField("Scene Manager Object", EditorStyles.boldLabel, GUILayout.Width(150));
        myManager = (GameObject)EditorGUILayout.ObjectField(myManager, typeof(GameObject), true);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal(GUILayout.Width(400));

        if (GUILayout.Button("Setup Scene Manager", GUILayout.Width(175), GUILayout.Height(25)))
        {
            if (myManager == null)
                alertOne = "You have to select your Object";
            else
            {
                SymbolController script1 = myManager.GetComponent(typeof(SymbolController)) as SymbolController;
                if (!script1)
                    myManager.AddComponent(typeof(SymbolController));

                CreateNewMaterial script2 = myManager.GetComponent(typeof(CreateNewMaterial)) as CreateNewMaterial;
                if (!script2)
                    myManager.AddComponent(typeof(CreateNewMaterial));
                
                alertOne = "Your Object is ready now";

            }
        }


        EditorGUILayout.LabelField(alertOne, EditorStyles.centeredGreyMiniLabel);
        EditorGUILayout.EndHorizontal();


        GUI.EndGroup();

        // Part 2 msg
        GUI.BeginGroup(new Rect(10, 10, 600, 500));
        GUILayout.Space(5);
        EditorGUILayout.BeginVertical(GUILayout.Width(400), GUILayout.Height(0));

        EditorGUILayout.HelpBox("2º Step \n \n Import your own Canvas Model to the Scene or UltraMare Canvas Model. \n \n You can jump this Step if you want to set you canvas latter", MessageType.Info, true); // Part 1 msg
        EditorGUILayout.EndVertical();


        //Canvas

        EditorGUILayout.BeginHorizontal(GUILayout.Width(400));

        EditorGUILayout.LabelField("Your Canvas Model", EditorStyles.boldLabel, GUILayout.Width(150));
        myCanvas = (Canvas)EditorGUILayout.ObjectField(myCanvas, typeof(Canvas), true);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal(GUILayout.Width(400));

        if (GUILayout.Button("Import Your Canvas", GUILayout.Width(175), GUILayout.Height(25)))
        { 
            if (myCanvas == null)
                alertTwo = "You have to select your own Canvas Model";
            else
            {
            Canvas ExampleCanvas = (Canvas)PrefabUtility.InstantiatePrefab(myCanvas);
            ExampleCanvas.name = "Canvas";
            alertTwo = "Your Canvas is ready now";
            }
        }
        EditorGUILayout.LabelField(alertTwo, EditorStyles.centeredGreyMiniLabel);

        EditorGUILayout.EndHorizontal();
        GUI.EndGroup();
    }
}

