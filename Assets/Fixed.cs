using UnityEngine;

public class Fixed : MonoBehaviour
{
    private void Awake()
    {
        R();
    }

    /// <summary>
    /// �ػ� ���� �Լ�
    /// </summary>
    public void R()
    {
        int W = 640; // ȭ�� �ʺ�
        int H = 1080; // ȭ�� ����

        //�ػ󵵸� �������� ���� ����
        //3��° �Ķ���ʹ� Ǯ��ũ�� ��带 ���� > true : Ǯ��ũ��, false : â���
        Screen.SetResolution(W, H, true);
    }
}