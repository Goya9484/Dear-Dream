using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{//각 씬으로 이동하는 스크립트
    public void GotoStoryScene()
    {
        SceneManager.LoadScene("StoryScene");
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void GotoStageSelectScene()
    {
        //타이틀씬의 BGM이 스토리 씬까지 이어지고 스테이지 선택 씬에서 다른 BGM이 나오게 하기위해
        //타이틀 씬의 BGM을 이 버튼 스크립트에서 종료
        GameObject.Find("TitleBGM").SetActive(false);
        SceneManager.LoadScene("StageSelect");
    }

    public void GotoStage01()
    {
        SceneManager.LoadScene("Stage01");
    }
    public void GotoStage02()
    {
        SceneManager.LoadScene("Stage02");
    }
    public void GotoStage03()
    {
        SceneManager.LoadScene("Stage03");
    }
    public void GotoHiddenStage()
    {
        SceneManager.LoadScene("HiddenStage");
    }
    public void GotoEnding()
    {//엔딩 분기점 체크(bool 타입의 Hidden Key가 false면 노말 엔딩, true면 히든 엔딩
        if (StageSelect.keyCount.Contains(1) && StageSelect.keyCount.Contains(2) &&
            StageSelect.keyCount.Contains(3) && StageSelect.hiddenKey == false)
            SceneManager.LoadScene("NomalEnding");
        else if (StageSelect.keyCount.Contains(1) && StageSelect.keyCount.Contains(2) &&
                StageSelect.keyCount.Contains(3) && StageSelect.hiddenKey == true)
            SceneManager.LoadScene("HiddenEnding");
    }

    public void Credits()
    {
        SceneManager.LoadScene("EndCredits");
    }

    public void GotoTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
