using UnityEngine;

public class Fixed : MonoBehaviour
{
    private void Awake()
    {
        R();
    }

    /// <summary>
    /// 해상도 고정 함수
    /// </summary>
    public void R()
    {
        int W = 640; // 화면 너비
        int H = 1080; // 화면 높이

        //해상도를 설정값에 따라 변경
        //3번째 파라미터는 풀스크린 모드를 설정 > true : 풀스크린, false : 창모드
        Screen.SetResolution(W, H, true);
    }
}