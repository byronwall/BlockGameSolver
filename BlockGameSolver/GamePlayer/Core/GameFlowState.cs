namespace BlockGameSolver.GamePlayer.Core
{
    public enum GameFlowState
    {
        Invalid,
        ReadyToFindBoard,
        ReadyToInitializeAnalysis,
        ReadyToAnalyze,
        ReadyToPlay,
        Playing,
        ReadyToQuitOrStartAgain,
        Finished,
        WaitingForClick,
        ForciblyQuit
    }
}