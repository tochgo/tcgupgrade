tcgupgrade
==========


自动上传压缩工具
作用：用于同城购开发团队多人合作开发升级时使用，升级文件列表文件upgrade.config，在开发工作完成后推送即可

使用.net 2.0 开发，使用时必须安装.net 2.0环境

upgrade.config 文件说明
属性说明：type:文件类型css、js ;bak="true"：备份，bak="false"不备份
<item type="css">test/test.css</item>//自动压缩，自动备份
<item type="js" bak="false">test/test.js</item> //自动压缩，不备份
<item>test/test.jpg</item>//上传并备份
<item bak="false">test/test.jpg</item>//上传不备份
<item>test/a/*.jpg</item>//批量上传

css文件支持压缩，默认备份

使用说明：将upgrade.config文件放到本地网站根目录，然后设置好相应的工具配置config.ini项就可使用了。

新增功能
2013-4-13
1.使用js压缩工具的时候可用google的Compiler库，需要设置java目录的环境变量 
2.多人协作使用新增了include语法，例子在upgrade.config中设置
3.自动识别了js、css文件类型，并能自动压缩
配置<include file="templates/upgrade.ini" defpath="templates" bak="false" type="list" />
<!--
defpath:默认路径名称，如果团队成员只允许一个目录的权限则有必要设置
bak:备份默认
type:只有值为list的时候，才允许下级配置列表使用单行文件列表
-->

<include file="upgrade.ini" defpath="" bak="false" type="list" />
<!--
upgrade.ini 文件配置说明
注释：采用符号;或者#开头的识别为注释
列表方式：直接写文件路径
-->
