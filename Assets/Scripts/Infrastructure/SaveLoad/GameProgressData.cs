using System;
using System.Collections.Generic;
using Infrastructure.Data;
using UnityEngine;

namespace Infrastructure.SaveLoad
{
    [Serializable]
    public class GameProgressData
    {
        public TankPositionData PlayerTankData;
        public List<TankPositionData> AiTanksData = new List<TankPositionData>();
    }
    
    [Serializable]
    public class TankPositionData
    {
        public Vector3Data Position;
        public float AngleRotation;
    }

}