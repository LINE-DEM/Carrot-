using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoTweenTest : MonoBehaviour
{
    private Image maskImage;
    private Tween maskTween;

    // Start is called before the first frame update
    void Start()
    {
        maskImage = GetComponent<Image>();

        ////1.doTween的静态方法
        //DOTween.To(() => maskImage.color, toColor => maskImage.color = toColor, new Color(0, 0, 0, 1),2);
        ////详细分析
        DOTween.To(
            () =>
            maskImage.color,//想改变的值
            toColor //写一个变量保存每次计算的结果
            => maskImage.color = toColor, //把结果赋值
            new Color(0, 0, 0, 0), 2);//目标值 ， 完成的时间

        //2.doTween 直接作用于Transfrom
        //因为是UI 移动全部是对于Canvas而言的 所以全用Local
        //Tween tween = transform.DOLocalMoveX(100, 0.5f);
        ////tween.PlayForward();
        //tween.PlayBackwards();

        //3.动画的循环使用
        //Play           只有一次
        //PlayForward    可以多次
        maskTween = transform.DOLocalMoveX(100, 0.5f);
        maskTween.SetAutoKill(false);
        maskTween.Pause();

        //4.动画的事件回调
        Tween tween = transform.DOLocalMoveX(100, 0.5f);
        tween.OnComplete(CompleteMethod);

        //5.设置动画的 缓动函数 以及 循环状态 和 次数
        tween.SetEase(Ease.InOutBounce);
        tween.SetLoops(-1 , LoopType.Incremental);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            maskTween.PlayForward();
        else if (Input.GetMouseButtonDown(1))
            maskTween.PlayBackwards();
    }

    private void CompleteMethod()
    {
        DOTween.To(() => maskImage.color, toColor => maskImage.color = toColor, new Color(0, 0, 0, 0), 2);
    }
}
