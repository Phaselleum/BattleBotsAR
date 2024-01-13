using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectParts : MonoBehaviour
{
        public GameObject[] weapons;
        public GameObject[] tools;

        public Bot ownBot;

        void Start()
        {
                ownBot = GameState.Instance.ownBot;
                if (ownBot == null) return;
                SelectWeapon(ownBot.weaponId);
                SelectTool(ownBot.toolId);
        }

        public void SelectWeapon(int id)
        {
                for (int i = 0; i < weapons.Length; i++)
                {
                        weapons[i].SetActive(i == id);
                        ownBot.weaponId = id;
                }
        }

        public void SelectTool(int id)
        {
                for (int i = 0; i < tools.Length; i++)
                {
                        tools[i].SetActive(i == id);
                        ownBot.toolId = id;
                }
        }
}
