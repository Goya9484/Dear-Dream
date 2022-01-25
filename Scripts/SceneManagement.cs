using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{//�� ������ �̵��ϴ� ��ũ��Ʈ
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
        //Ÿ��Ʋ���� BGM�� ���丮 ������ �̾����� �������� ���� ������ �ٸ� BGM�� ������ �ϱ�����
        //Ÿ��Ʋ ���� BGM�� �� ��ư ��ũ��Ʈ���� ����
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
    {//���� �б��� üũ(bool Ÿ���� Hidden Key�� false�� �븻 ����, true�� ���� ����
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
