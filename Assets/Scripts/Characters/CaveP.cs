using System.Collections.Generic;
using UnityEngine;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Characters
{

    public class CaveP : MonoBehaviour
    {
        private const int HP = 10;
        private const int MP = 5;
        private const int SPE = 8;
        private const int RAN = 6;
        private const int DMG = 10;
        private const int MDMG = 1;
        private const int DEF = 6;
        private const int MDEF = 2;
        private const int LVL = 1;
        
        private void Awake()
        {
            var charScript = GetComponent<Character>();
            List<int> stats;
            if (charScript.isRespawning) stats = charScript.CurrentStats();
            else stats = new List<int> { HP, MP, SPE, RAN, DMG, MDMG, DEF, MDEF, LVL };
            charScript.RestoreStats(stats);
        }
    }
}