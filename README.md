# KDE
核密度估计（kernel density estimation） c# 实现


问题背景
核密度估计（kernel density estimation）是在概率论中用来估计未知的密度函数，属于非参数检验方法之一，由Rosenblatt (1955)和Emanuel Parzen(1962)提出，又名Parzen窗（Parzen window）。
具体原理推导可参考这篇博客。
此篇博客侧重于根据理论公式 
 
理论基础
核密度估计的核心公式如下：
![avatar](https://github.com/zluckymn/KDE/blob/main/1.png)

在这里插入图片描述
![avatar](https://github.com/zluckymn/KDE/blob/main/2.png)

其中，h为带宽（band_width）,K(.)为核函数，本文选取高斯核。

在这里插入图片描述
带宽h是一个超参数，h越小，邻域中参与拟合的点越少。h有多种选取方式，
本文参考网上资料采用如下公式：
![avatar](https://github.com/zluckymn/KDE/blob/main/3.png)

在这里插入图片描述
其中c=1.05*数据序列标准差
