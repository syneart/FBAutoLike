
' FB 自動點讚 by SyneArt
' https://syneart.com
'
' 版本變更:
' 2016 年 05 月 09 日 - FBAutoLike v1.4 / 修復按讚功能 與 增加回覆讚功能
' 2013 年 02 月 24 日 - FBAutoLike v1.3 / 增加動態讚與留言讚的按讚選擇 與 狀態顯示方式微調
' 2013 年 02 月 16 日 - FBAutoLike v1.2 / 增加間隔時間控制 與 剩餘時間顯示
' 2013 年 02 月 04 日 - FBAutoLike v1.1 / 增加自動停止時間控制 與 濾除圖片(速度優化)
' 2013 年 02 月 02 日 - FBAutoLike v1.0

Imports System.Threading

Public Class MainForm
    Dim urlFBHomePage As String = "https://www.facebook.com/"
    Dim isPressLike As Boolean, isButtonStartActionEnable As Boolean
    Dim stopTime As Date
    Dim remainingTime As String, myTitle As String
    Dim TimeTread As Thread
    Dim intDelayTime As Integer

    ' 使程式完全終止，釋放資源
    Private Sub MainForm_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        End
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        ' 啟動程式時就瀏覽 Facebook 的首頁
        MyWebBrowser.Navigate(urlFBHomePage)
        ' 啟動程式時預設為按讚
        isPressLike = True
        ' 紀錄目前程式標題
        myTitle = Me.Text
        ' 避免跨執行序呼叫錯誤
        CheckForIllegalCrossThreadCalls = False
        ' 計算時間執行序
        TimeTread = New Thread(AddressOf showTime)
        TimeTread.Start()
    End Sub

    Private Sub ButtonStartAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStartAction.Click
        ' 切換開始/停止 與 按鈕的致能
        MainTimer.Enabled = Not MainTimer.Enabled
        ButtonStartAction.Text = IIf(MainTimer.Enabled, "停止", "開始")
        RadioButtonTypePressLike.Enabled = IIf(MainTimer.Enabled, False, True)
        RadioButtonTypePressUnLike.Enabled = IIf(MainTimer.Enabled, False, True)

        ' 按讚類型 [動態讚、留言讚、回覆讚]
        CheckBoxChooseTypeFeed.Enabled = IIf(MainTimer.Enabled, False, True)
        CheckBoxChooseTypeComment.Enabled = IIf(MainTimer.Enabled, False, True)
        CheckBoxChooseTypeReply.Enabled = IIf(MainTimer.Enabled, False, True)

        ' 時間
        LabelShowTimeText.Enabled = IIf(MainTimer.Enabled, False, True)
        CheckBoxEnableLimitTime.Enabled = IIf(MainTimer.Enabled, False, True)
        NumericUpDownLimitTime.Enabled = IIf(MainTimer.Enabled, False, True)
        NumericUpDownDelayTime.Enabled = IIf(MainTimer.Enabled, False, True)

        ' 設定自動停止時間 (如有勾選), 單位:分鐘
        If CheckBoxEnableLimitTime.Checked Then stopTime = Now.AddMinutes(NumericUpDownLimitTime.Value)
        ' 設定執行間隔時間, 單位:秒鐘
        MainTimer.Interval = NumericUpDownDelayTime.Value * 1000
        ' 設定顯示執行間隔時間
        intDelayTime = NumericUpDownDelayTime.Value
        ' 重新整理網頁內容
        MyWebBrowser.Refresh()
    End Sub

    ' Timer 預設為 10 秒執行一次
    Private Sub MainTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainTimer.Tick
        ' 如果網頁已讀取完成
        If MyWebBrowser.ReadyState = WebBrowserReadyState.Complete Then
            Dim htmlDocument As HtmlDocument = MyWebBrowser.Document
            ' 不顯示圖片
            For Each element In htmlDocument.GetElementsByTagName("img")
                element.OuterHtml = ""
            Next

            For Each element In htmlDocument.GetElementsByTagName("a")
                ' 判斷 "讚" 或 "收回讚" 的連結 [由 isPressLike 參數決定]
                If CheckBoxChooseTypeFeed.Checked And element.GetAttribute("data-testid").Contains(IIf(isPressLike, "fb-ufi-likelink", "fb-ufi-unlikelink")) Then
                    element.InvokeMember("click") ' 動態讚
                End If

                If element.GetAttribute("data-ft").Contains(IIf(isPressLike, "{""tn"":"">""}", "{""tn"":""?""}")) Then
                    If CheckBoxChooseTypeComment.Checked And element.GetAttribute("data-testid").Contains("ufi_comment_like_link") Then
                        element.InvokeMember("click") ' 留言讚
                    End If
                    If CheckBoxChooseTypeReply.Checked And element.GetAttribute("data-testid").Contains("ufi_reply_like_link") Then
                        element.InvokeMember("click") ' 回覆讚
                    End If
                End If
            Next
            ' 時間到自動停止
            If CheckBoxEnableLimitTime.Checked And stopTime < Now Then ButtonStartAction_Click(sender, e)
            ' 將瀏覽器卷軸捲到最底，以讓 FB 讀取新內容
            htmlDocument.Window.ScrollTo(0, htmlDocument.Body.ScrollRectangle.Height)
            ' 確保延遲時間顯示正確
            intDelayTime = NumericUpDownDelayTime.Value
        End If
    End Sub

    Private Sub RadioButtonTypePress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonTypePressLike.CheckedChanged, RadioButtonTypePressUnLike.CheckedChanged
        ' 由使用者選擇 "讚" 或 "收回讚"
        isPressLike = IIf(DirectCast((sender), RadioButton).Name = "RadioButtonPressLike", True, False)
    End Sub

    ' 判斷是否正在讀取網頁
    Private Sub MyWebBrowser_ProgressChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles MyWebBrowser.ProgressChanged
        If MyWebBrowser.ReadyState = WebBrowserReadyState.Complete Then
            isButtonStartActionEnable = True
            ButtonStartAction.Text = IIf(MainTimer.Enabled, "停止", "開始")
        Else
            isButtonStartActionEnable = False
            ButtonStartAction.Text = "等待網頁"
        End If
        CheckBoxChooseType_CheckedChanged(sender, e)
    End Sub

    ' 顯示目前計算的時間
    Private Sub showTime()
        While True
            Thread.Sleep(1000)
            Application.DoEvents()
            Me.Text = myTitle
            intDelayTime = (intDelayTime + 1) Mod NumericUpDownDelayTime.Value
            If MainTimer.Enabled Then
                Me.Text &= " (延遲: " & NumericUpDownDelayTime.Value - intDelayTime & " 秒"
                Me.Text &= IIf(CheckBoxEnableLimitTime.Checked, " ，剩餘: " & (Now - stopTime).ToString("mm") & " 分 " & (Now - stopTime).ToString("ss") & " 秒)", ")")
            End If
        End While
    End Sub

    ' 確定目前能不能開始執行
    Private Sub CheckBoxChooseType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxChooseTypeFeed.CheckedChanged, CheckBoxChooseTypeComment.CheckedChanged, CheckBoxChooseTypeReply.CheckedChanged
        ButtonStartAction.Enabled = (CheckBoxChooseTypeFeed.Checked Or CheckBoxChooseTypeComment.Checked Or CheckBoxChooseTypeReply.Checked) And isButtonStartActionEnable
    End Sub

End Class