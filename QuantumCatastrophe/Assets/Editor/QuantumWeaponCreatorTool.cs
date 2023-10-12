using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class QuantumWeaponCreatorTool : EditorWindow
{
    [MenuItem("QuantumTools/Weapon Editor")]
    public static void Init()
    {
        QuantumWeaponCreatorTool QWC = EditorWindow.GetWindow<QuantumWeaponCreatorTool>();
        QWC.title = "QWC by Nekx86";

        QWC.Show();
    }
    private GameObject _weaponModel;
    public void OnGUI()
    {
        EditorGUILayout.LabelField("Weapon Creator Tool by Nekx86");
        EditorGUILayout.ObjectField("Weapon Model", _weaponModel, typeof(GameObject));
        if (GUILayout.Button("Create a Custom Weapon"))
        {
            CreateWeapon();
        }
        EditorGUILayout.HelpBox("Early Access - Build 1301 / Nekx86 ",MessageType.Info);
    }

    private void CreateWeapon()
    {
        throw new NotImplementedException();
    }
}
