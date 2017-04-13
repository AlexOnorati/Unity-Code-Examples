using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Equipment))]
public class EquipmentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        int size = 64;
        Equipment scriptTarget = (Equipment)target;

        
        EditorGUILayout.BeginHorizontal(GUILayout.Width(size * 3));
        GUILayout.Space(size + 3);
        EditorGUILayout.BeginVertical();
        
        if (scriptTarget.head != null)
        {
            
            if (GUILayout.Button(scriptTarget.head.image, GUILayout.Width(size), GUILayout.Height(size)))
            {
                ViewArmor.Init(scriptTarget.head);
            }
        }
        else
        {
            EditorGUILayout.LabelField("Head", GUI.skin.box,GUILayout.Width(size), GUILayout.Height(size));
        }
        Head headOld = scriptTarget.head;
        scriptTarget.head = (Head)EditorGUILayout.ObjectField(scriptTarget.head, typeof(Head), false, GUILayout.Width(size));
        if (headOld != scriptTarget.head) {
            EditorUtility.SetDirty(scriptTarget);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal(GUILayout.Width(size * 3));
       
        EditorGUILayout.BeginVertical();
       
        
        if (scriptTarget.leftArm != null) {
            
            if (GUILayout.Button(scriptTarget.leftArm.image, GUILayout.Width(size), GUILayout.Height(size)))
            {
                ViewArmor.Init(scriptTarget.leftArm);
            }
        }
        else
        {
            EditorGUILayout.LabelField("Left Arm", GUI.skin.box, GUILayout.Width(size), GUILayout.Height(size));
        }
        Arm leftArmOld = scriptTarget.leftArm;
        scriptTarget.leftArm = (Arm)EditorGUILayout.ObjectField(scriptTarget.leftArm, typeof(Arm), false, GUILayout.Width(size));
        if (leftArmOld != scriptTarget.leftArm) {
            EditorUtility.SetDirty(scriptTarget.leftArm);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        
        if (scriptTarget.chest != null)
        {

            if (GUILayout.Button(scriptTarget.chest.image, GUILayout.Width(size), GUILayout.Height(size)))
            {
                ViewArmor.Init(scriptTarget.chest);
            }
        }
        else {
            EditorGUILayout.LabelField("Chest", GUI.skin.box, GUILayout.Width(size), GUILayout.Height(size));
        }
        Chest chestOld = scriptTarget.chest;
        scriptTarget.chest = (Chest)EditorGUILayout.ObjectField(scriptTarget.chest, typeof(Chest), false, GUILayout.Width(size));
        if (chestOld != scriptTarget.chest) {
            EditorUtility.SetDirty(scriptTarget);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();

        if (scriptTarget.rightArm != null)
        {

            if (GUILayout.Button(scriptTarget.rightArm.image, GUILayout.Width(size), GUILayout.Height(size)))
            {
                ViewArmor.Init(scriptTarget.rightArm);
            }
        }
        else
        {
            EditorGUILayout.LabelField("Right Arm", GUI.skin.box, GUILayout.Width(size), GUILayout.Height(size));
        }
        Arm rightArmOld = scriptTarget.rightArm;
        scriptTarget.rightArm = (Arm)EditorGUILayout.ObjectField(scriptTarget.rightArm, typeof(Arm), false, GUILayout.Width(size));
        if (rightArmOld != scriptTarget.rightArm) {
            EditorUtility.SetDirty(scriptTarget);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal(GUILayout.Width(size * 3));
        EditorGUILayout.BeginVertical();

        if (scriptTarget.leftHand != null)
        {

            if (GUILayout.Button(scriptTarget.leftHand.image, GUILayout.Width(size), GUILayout.Height(size)))
            {
                ViewWeapon.Init(scriptTarget.leftHand);
            }
        }
        else
        {
            EditorGUILayout.LabelField("Left Hand", GUI.skin.box, GUILayout.Width(size), GUILayout.Height(size));
        }
        Weapon leftHandOld = scriptTarget.leftHand;
        scriptTarget.leftHand = (Weapon)EditorGUILayout.ObjectField(scriptTarget.leftHand, typeof(Weapon), false, GUILayout.Width(size));
        if (leftHandOld != scriptTarget.leftHand) {
            EditorUtility.SetDirty(scriptTarget);
        }
        EditorGUILayout.EndVertical();
       
       
        EditorGUILayout.BeginVertical();
       
        if (scriptTarget.legs != null) {
           
            if (GUILayout.Button(scriptTarget.legs.image, GUILayout.Width(size), GUILayout.Height(size)))
            {
                ViewArmor.Init(scriptTarget.legs);
            }
        }
        else
        {
            EditorGUILayout.LabelField("Legs", GUI.skin.box, GUILayout.Width(size), GUILayout.Height(size));
        }
        Leg legOld = scriptTarget.legs;
        scriptTarget.legs = (Leg)EditorGUILayout.ObjectField(scriptTarget.legs, typeof(Leg), false, GUILayout.Width(size));
        if (legOld != scriptTarget.legs) {
            EditorUtility.SetDirty(scriptTarget);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();

        if (scriptTarget.rightHand != null)
        {

            if (GUILayout.Button(scriptTarget.rightHand.image, GUILayout.Width(size), GUILayout.Height(size)))
            {
                ViewWeapon.Init(scriptTarget.rightHand);
            }
        }
        else
        {
            EditorGUILayout.LabelField("Right hand", GUI.skin.box, GUILayout.Width(size), GUILayout.Height(size));
        }
        Weapon rightHandOld = scriptTarget.rightHand;
        scriptTarget.rightHand = (Weapon)EditorGUILayout.ObjectField(scriptTarget.rightHand, typeof(Weapon), false, GUILayout.Width(size));
        if (rightHandOld != scriptTarget.rightHand) {
            EditorUtility.SetDirty(scriptTarget);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal(GUILayout.Width(size * 3));
        GUILayout.Space(size + 3);
        EditorGUILayout.BeginVertical();
       
       
        if (scriptTarget.boots != null) {
            
            if (GUILayout.Button(scriptTarget.boots.image, GUILayout.Width(size), GUILayout.Height(size)))
            {
                ViewArmor.Init(scriptTarget.boots);
            }
        }
        else
        {
            EditorGUILayout.LabelField("Boots", GUI.skin.box, GUILayout.Width(size), GUILayout.Height(size));
        }
        Boot bootsOld = scriptTarget.boots;
        scriptTarget.boots = (Boot)EditorGUILayout.ObjectField(scriptTarget.boots, typeof(Boot), false, GUILayout.Width(size));
        if (bootsOld != scriptTarget.boots) {
            EditorUtility.SetDirty(scriptTarget);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
    }
}