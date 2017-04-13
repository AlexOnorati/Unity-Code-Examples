using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class GenerateMaze : EditorWindow
{
    List<GameObject> encounters = new List<GameObject>();
    GameObject boss;
    int keys = 5;
    int checkPointCount = 11;
    int width = 10;
    int length = 10;
    int height = 10;
    string seed = "";
    bool isUsingSeed = false;
    bool finalize = false;
   
    float ratio = .5f;
    MazeType currentMazeType = MazeType.Labyrinth;

    [MenuItem("Tools/Generate Maze")]
    static void Init()
    {
        GenerateMaze mazeWindow = (GenerateMaze)EditorWindow.GetWindow(typeof(GenerateMaze));
        mazeWindow.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Maze Type");
        currentMazeType = (MazeType)EditorGUILayout.EnumPopup(currentMazeType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();


        switch (currentMazeType) {
            case MazeType.Wireframe:

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Check Points");
                checkPointCount = EditorGUILayout.IntSlider(checkPointCount, 1, 10);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Height:");
                height = EditorGUILayout.IntSlider(height, 1, 30);
                EditorGUILayout.EndHorizontal();
                break;
            case MazeType.Labyrinth:

                GUILayout.Label("Encounters", EditorStyles.boldLabel);



                
                GameObject[] encountersArray = encounters.ToArray();
                for (int i = 0; i < encountersArray.Length; i++)
                {
                    encountersArray[i] = (GameObject)EditorGUILayout.ObjectField(encountersArray[i], typeof(GameObject), false);

                }
                encounters = new List<GameObject>(encountersArray);
                EditorGUILayout.BeginHorizontal();
                if (encounters.Count == 0)
                {
                    encounters.Add(null);
                }
                else
                {
                    if (GUILayout.Button("Add Encounter", GUILayout.Width(120), GUILayout.Height(15)))
                    {
                        encounters.Add(null);
                    }
                    if (encounters.Count > 1 && GUILayout.Button("Remove Encounter", GUILayout.Width(120), GUILayout.Height(15)))
                    {
                        encounters.Remove((encounters.ToArray())[encounters.Count - 1]);
                    }
                }
                
                EditorGUILayout.EndHorizontal();

                GUILayout.Label("Boss Encounter", EditorStyles.boldLabel);
                boss = (GameObject)EditorGUILayout.ObjectField(boss, typeof(GameObject), false);

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Key Total");
                keys = EditorGUILayout.IntSlider(keys, 1, 10);
                EditorGUILayout.EndHorizontal();
                
                break;
        }


        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Width:");
        width = EditorGUILayout.IntSlider(width, 1, 30);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Length:");
        length = EditorGUILayout.IntSlider(length, 1, 30);
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Room Ratio");
        ratio = EditorGUILayout.Slider(ratio, 0.1f, .9f);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        isUsingSeed = EditorGUILayout.BeginToggleGroup("Seed", isUsingSeed);
        seed = EditorGUILayout.TextField(seed);
        EditorGUILayout.EndToggleGroup();
        EditorGUILayout.EndHorizontal();
        int filledEncounters = 0;
        foreach (GameObject encounter in encounters) {
            if (encounter != null) {
                filledEncounters++;
            }
        }
        if (!finalize && ((MazeType.Wireframe == currentMazeType) || (MazeType.Labyrinth == currentMazeType && filledEncounters == encounters.Count && boss != null)))
            {
            bool generate = false;
            bool isRandom = false;
            if (GUILayout.Button("Build SingleBlock"))
            {
                generate = true;
            }
            if (GUILayout.Button("Generate Maze"))
            {
                generate = true;
                isRandom = true;
            }
            if (generate) { 
                GameObject conMan = new GameObject();
                conMan.AddComponent<ConstructionManager>();
                conMan.name = "ConstructionManager";
                ConstructionManager.instance = conMan.GetComponent<ConstructionManager>();
                if (ConstructionManager.instance.IsLabyrinth())
                {
                    LabyrinthManager.instance = GameObject.Find("LabyrinthManager").GetComponent<LabyrinthManager>();
                    ConstructionManager.instance.labyrinthObjects = encounters.ToArray();
                }
                else {
                    ConstructionManager.instance.labyrinthObjects = null;
                }
                if (isRandom)
                {
                    ConstructionManager.instance.SetUpMainBlock(isUsingSeed, seed, width, 1, length, ratio, currentMazeType == MazeType.Labyrinth);
                }
                else {
                    ConstructionManager.instance.SetUpMainBlock(currentMazeType == MazeType.Labyrinth);
                }

                ConstructionManager.instance.BuildByMap();
                if (currentMazeType == MazeType.Labyrinth) {
                    ConstructionManager.instance.BuildOnRoom(boss);
                }
                finalize = true;
                FaceCollider.inBuild = true;
                generate = false;
                isRandom = false;
            }
        }

        if (finalize && GUILayout.Button("Save Maze"))
        {

            
            GameObject mapObject;
            mapObject = ConstructionManager.instance.SaveSetUp();
            if (MazeType.Wireframe == currentMazeType) {
                PongManager.instance = GameObject.Find("PongManager").GetComponent<PongManager>();
            }
            mapObject.transform.SetParent(MazeType.Labyrinth == currentMazeType ? LabyrinthManager.instance.transform : PongManager.instance.transform, false);
            mapObject.GetComponent<Map>().SetPlayerTranform(Camera.main.transform);
            DestroyImmediate(ConstructionManager.instance.gameObject);
            finalize = false;
            FaceCollider.inBuild = false;
        }
        if (ConstructionManager.instance == null) {
            finalize = false;
        }
    }
    
    private enum MazeType {
        Wireframe,
        Labyrinth
    }
}