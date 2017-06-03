# 欢迎使用PowerShell 多线程组件
> 作者： 陈希章 发表于 2017年6月3日

## 应用场景
多线程在需要批量处理一些任务的时候相当有用，也更加有利于充分利用现有计算机的能力。所有主流的开发语言都支持多线程。

默认情况下，PowerShell作为一个脚本语言，是不支持多线程操作的，虽然有所谓的后台任务，但实际上控制起来相当麻烦。

我很喜欢PowerShell，所以为此专门写了一个自定义的模块，来实现多线程的功能。该模块使用C#编写，源代码可以在下面的地址访问到
<https://github.com/chenxizhang/MultiThreadTaskRunner>

与此同时，这个模块已经打包发布到微软官方的PowerShell Gallery中
<https://www.powershellgallery.com/packages/MultiThreadTaskRunner>

## 使用说明

1. 要使用该模块，首先需要进行安装（请用管理员身份打开PowerSehll）

```
Install-Module -Name MultiThreadTaskRunner 
```
你可以通过下面的命令查看帮助文档
```
Get-Help New-MultiTaskJob -Full
```

2. 准备一个用来测试的脚本块

```
$script ={
param($obj);
Write-Host $obj
}
```

3.使用类似下面的方式调用即可
```
New-MultiTaskJob –Source 1..100 –Block $script –ThreadCount 10
```
这个命令的意思是指，用10个并行的线程，处理传入的100个数字，实际上每个线程分配得到的数字是10个，然后使用此前定义好的脚本块执行它

希望对大家有所帮助

