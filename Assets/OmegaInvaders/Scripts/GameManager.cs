using UnityEngine;

namespace Reefaktor.Omega
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private PlayerShipController playerPrefab;
        [SerializeField] private SpaceBackgroundController backgroundController;
        private PlayerShipController playerShip;
        


        #region Unity Member Functions

        private void Start()
        {
            Initialize();
        }
        

        #endregion

        private void Initialize()
        {
            playerShip = Instantiate(playerPrefab);
            playerShip.Initialize(mainCamera);
            
            StartGame();
        }

        private void StartGame()
        {
            backgroundController.Play();
            playerShip.Setup();
        }

        private void FinishGame()
        {
            backgroundController.Stop();
        }
        
        
    }
}