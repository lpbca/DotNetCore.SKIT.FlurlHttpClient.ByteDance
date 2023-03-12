﻿## 如何快速找到需要调用的 API 模型类名 / 方法名？

---

本库提供的请求模型、响应模型和接口方法，三者均保持同名。

例如，获取粉丝列表的请求是 `FansListRequest`，响应是 `FansListResponse`，接口是 `ExecuteFansListAsync()`。知道其中一个，其余两个就可以快速地推断出了。

再有，每个对象的命名与官方文档的接口地址大体保持一致。例如刚刚提到的获取粉丝列表，它的接口地址是 `[GET] /fans/list`，将其中的反斜杠去掉、并以大驼峰命名法的方式调整它，就可以得到前文提到的几个对象了。

完整的模型定义可以参考项目目录下的 _src/SKIT.FlurlHttpClient.ByteDance.DouyinOpen/Models_ 目录。

---

### 抖音开放平台 API 支持情况：

<details>

<summary>[展开查看]</summary>

|     |              抖音 API              | 备注 |
| :-: | :--------------------------------: | :--: |
|  √  |              账号授权              |      |
|  √  |              用户管理              |      |
|  √  |              视频管理              |      |
|  √  |              视频管理              |      |
|  √  |              视频管理              |      |
|  √  |              互动管理              |      |
|  √  |              互动管理              |      |
|  √  |              搜索管理              |      |
|  √  |            数据开放服务            |      |
|  √  |    企业号开放能力：管理意向用户    |      |
|  √  |      企业号开放能力：评论管理      |      |
|  √  |      企业号开放能力：私信管理      |      |
|  √  |    企业号开放能力：企业消息卡片    |      |
|  √  | 生活服务开放能力：抖音生活服务接口 |      |
|  √  |    生活服务开放能力：小程序接口    |      |
|  √  |         工具能力：素材管理         |      |
|  √  |      工具能力：小程序接口能力      |      |
|  √  |         工具能力：沙盒管理         |      |
|  √  |         工具能力：JSB 管理         |      |
|  √  |   服务市场开放能力：服务订购关系   |      |

</details>