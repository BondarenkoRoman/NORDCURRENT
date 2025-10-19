using System;
using Infrastructure.Data;
using Infrastructure.GameFactories;
using Infrastructure.GameSession;
using UnityEngine;
using Zenject;

namespace Infrastructure.SaveLoad
{
    public class SaveLoadService : ISaveLoadService, IDisposable
    {
        [Inject] private readonly IGameSessionService _gameSessionService;
        [Inject] private readonly IGameFactory _gameFactory;
        private const string ProgressKey = "Progress";
        
        public void Initialize()
        {
            LoadProgress();
        }
    
        public void Dispose()
        {
            SaveProgress();
        }

        private void SaveProgress()
        {
            _gameFactory.Cleanup();
        
            foreach (IProgressSaver progressSaver in _gameFactory.ProgressSavers)
                if (progressSaver != null && (progressSaver as MonoBehaviour) != null)
                    progressSaver.Save(_gameSessionService.GameProgressData);

            PlayerPrefs.SetString(ProgressKey, _gameSessionService.GameProgressData.ToJson());
        }

        private void LoadProgress()
        {
            _gameSessionService.GameProgressData = PlayerPrefs.GetString(ProgressKey)?
                .ToDeserialized<GameProgressData>();
        }
    }
}
