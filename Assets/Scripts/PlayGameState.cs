using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayGameState : MonoBehaviour, IGameState
    {
        private readonly MenuActivator menuActivator = MenuActivator.GetInstance();
        public PlayMenu playMenu;
        public CheckeredBoard board;
        public BoardStorage storage;
        public TurnManager turnManager;
        public TimerManager timerManager;
        public RoundJudge roundJudge;
		public BonusManager bonusManager;
        public RoundScore roundScore;

        private int currentRound = 0;
        private int turnsLeft = 0;

        public void InvokeState()
        {
            menuActivator.OpenMenu(playMenu);
            roundJudge.OnFinishJudge += OnFinishRound;
            InitNewGame();
        }

        public void CloseState()
        {
            menuActivator.CloseMenu();
        }

        public void InitNewRound()
        {
			bonusManager.Reset();
            turnManager.InitRound();
            turnsLeft = 0;
            currentRound++;

            playMenu.UpdateRoundText(currentRound);
            storage.Reset();

            if (currentRound > 5)
            {
                //end game
                return;
            }
            
            if (currentRound == 1)
            {
                turnManager.SetTurn(GetFirstTurn());
            }
            else if (currentRound > 1)
            {
                turnManager.SetNextTurn();    
            }

            timerManager.StartTimer();
        }

        public void OnFinishTurn(TurnType finishedType)
        {
            Debug.Log("Finished turn");
			bonusManager.Reset();
            ChangeTurn();
        }

        public void OnFinishRound()
        {
            playMenu.UpdateScoreText(roundScore);
            InitNewRound();
        }

        //To single play and debug
        public void ChangeTurn()
        {
            turnsLeft++;
            if (turnsLeft == 2)
            {
                turnManager.SetTurn(TurnType.RESULT);
                timerManager.StopTimer();
                roundJudge.StartJudge();
            }
            else
            {
                turnManager.SetNextTurn();
                timerManager.StartTimer();
            }
        }

        public void InitNewGame()
        {
            board.DeleteButtons();
            board.CreateButtons();
            InitNewRound();
        }

        private TurnType GetFirstTurn()
        {
            return TurnType.MOUSE;
        }
    }
}