# ToastNotification
Show an android style toast notification in Windows Form.

[![](https://img.shields.io/github/license/philippewaty/ToastNotification.svg?style=flat-square)](https://github.com/philippewaty/ToastNotification/blob/master/LICENSE)
[![](https://img.shields.io/github/commit-activity/y/philippewaty/ToastNotification.svg?style=flat-square)](https://github.com/philippewaty/ToastNotification/commits/master)
[![](https://img.shields.io/github/issues/philippewaty/ToastNotification.svg?style=flat-square)](https://github.com/philippewaty/ToastNotification/issues)
[![Release](https://img.shields.io/github/release/philippewaty/ToastNotification.svg?style=flat-square)](https://github.com/philippewaty/ToastNotification/releases)

Dependencies :
Framework 4.5

Sample :
```C#
ToastNotification.NotificationManager.Show(this, "Lorem ipsum dolor sit amet.", System.Drawing.Color.Green, 3000, new System.Drawing.Font(this.Font.Name, 10));
```
![alt text](ToastNotification.png)

Original code from

https://www.codeproject.com/Articles/442983/Android-Style-Toast-Notification-for-NET
