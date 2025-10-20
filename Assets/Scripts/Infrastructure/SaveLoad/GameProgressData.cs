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

        public bool IsPlayerTankDataValid()
        {
            return PlayerTankData != null && PlayerTankData.IsValid();
        }
    }
    
    [Serializable]
    public class TankPositionData
    {
        public Vector3Data Position;
        public float AngleRotation;

        public bool IsValid()
        {
            if (Position == null)
                return false;
                
            if (Mathf.Approximately(Position.X, 0f) && 
                Mathf.Approximately(Position.Y, 0f) && 
                Mathf.Approximately(Position.Z, 0f))
                return false;
                
            if (Mathf.Approximately(AngleRotation, 0f))
                return false;
                
            return true;
        }
    }

}