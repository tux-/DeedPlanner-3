﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Warlander.Deedplanner.Gui.Widgets;

namespace Warlander.Deedplanner.Gui
{
    public class GuiManager : MonoBehaviour
    {
        public static GuiManager Instance { get; private set; }

        [SerializeField] private RectTransform[] interfaceTransforms = null;

        [SerializeField] private UnityTree groundsTree = null;
        [SerializeField] private UnityTree cavesTree = null;
        [SerializeField] private UnityTree floorsTree = null;
        [SerializeField] private UnityTree wallsTree = null;
        [SerializeField] private UnityList roofsList = null;
        [SerializeField] private UnityTree objectsTree = null;

        public UnityTree GroundsTree => groundsTree;
        public UnityTree CavesTree => cavesTree;
        public UnityTree FloorsTree => floorsTree;
        public UnityTree WallsTree => wallsTree;
        public UnityList RoofsList => roofsList;
        public UnityTree ObjectsTree => objectsTree;

        public GuiManager()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                foreach (RectTransform interfaceTransform in interfaceTransforms)
                {
                    interfaceTransform.gameObject.SetActive(!interfaceTransform.gameObject.activeSelf);
                }
            }
        }
    }
}