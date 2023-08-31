using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LevelStateManager : MonoBehaviour
{
    public List<Level> Level;
    public Level ActiveLevel;
}

[Serializable]
public class Level
{
    public string LevelName;
    public Sprite LevelPreShow;
    public bool LevelCompleted;
}

