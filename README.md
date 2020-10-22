## WaterSurface Rendering 水面渲染

![](https://img.shields.io/badge/platform-windows-lightgrey.svg)
![](https://img.shields.io/badge/language-C-orange.svg)
![](https://img.shields.io/badge/OpenGL-3.3-green.svg)

### 目标结果：
###### 用openGL模拟水面

### 结果参考：
##### sine波叠加
![image](https://github.com/kevin3134/HW2_WaterSurface/blob/master/resource/sinewave.png)
##### gestner波叠加
![image](https://github.com/kevin3134/HW2_WaterSurface/blob/master/resource/gestnerWave.png)
##### gestner波叠加 + 光照
![image](https://github.com/kevin3134/HW2_WaterSurface/blob/master/resource/gestnerWaveWithLight.png)

### 思路：
##### 1，生成均匀分布的顶点，画出平面
##### 2，在shader中画出sine或者gerstner波
##### 3，添加光照/skybox，计算反射光，优化结果图

### 实际做法：
##### 1，首先考虑三维世界中，y作为向上的轴，xz为平面基底。生成均匀的x，z顶点，y为xz的因变量。
##### 2，基于公式y=H(x,z,t)，分别把sine函数和gerstner函数的变量对应到C的struct，并用计算多个随机方向的函数叠加。根据结果y的位置和其对应的法向量画出水波。
##### 3，添加skybox立方体贴图作为光源，考虑Fersnel Effect的折射和反射比例，用通过各个点的位置和法线，得到反射对应的光源，并和全局光照结合，优化水面效果。

### bug和未来的优化：
##### 1，光照部分，立方体贴图效果不好，并且折射光没有考虑，反射只考虑单次反射
##### 2，sine波实际效果不佳，gerstner波需要大量调参才有好的效果
##### 3，hardcode和magic number较多

### 使用库：
###### glm，glad，glfw

### 参考：
###### 1，真实海洋的绘制，大量学习并使用，非常感谢 
https://hehao98.github.io/year-archive/
###### 2，simulating Ocean Water, 很棒的海水模拟，光照部分很全面 
http://www-evasion.imag.fr/Membres/Fabrice.Neyret/NaturalScenes/fluids/water/waves/fluids-nuages/waves/Jonathan/articlesCG/simulating-ocean-water-01.pdf
###### 3，Unity Gerstner Waves(模拟大海波浪)，主要介绍Gerstner波的模拟 
https://blog.csdn.net/zakerhero/article/details/100113375
###### 4，GPU Gems，对Gerstner波的数学原理非常详细和实用
https://developer.nvidia.com/gpugems/gpugems/part-i-natural-effects/chapter-1-effective-water-simulation-physical-models

