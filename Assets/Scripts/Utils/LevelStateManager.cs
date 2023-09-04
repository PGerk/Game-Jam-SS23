using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LevelStateManager : MonoBehaviour
{
    public HashSet<Level> Level;
    public Level ActiveLevel;

    private void Awake()
    {
        this.Level = new HashSet<Level>();
    }
}

